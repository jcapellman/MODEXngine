using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Enums;
using MODEXngine.lib.Renderer.Base;
using MODEXngine.lib.Renderer.Objects;

namespace MODEXngine.lib.Base
{
    public abstract class BaseRenderer
    {
        protected string GameTitle;
        protected Settings Settings;

        public event EventHandler<(EventTypes eventType, object obj)> EventOccurred;

        protected void OnEventOccurred(EventTypes eventType, object payload = null)
        {
            EventOccurred?.Invoke(null, (eventType, payload));
        }

        public event EventHandler WindowClosed;

        protected void OnWindowClosed()
        {
            WindowClosed?.Invoke(this, null);
        }

        public void SetGameLaunchItems(string gameTitle, Settings settings)
        {
            GameTitle = gameTitle;
            Settings = settings;
        }

        public abstract string Name { get; }

        public abstract void Initialize();

        public abstract void Start();

        public abstract List<Resolution> SupportedResolutions();

        public void InitializeImplementations(Type renderer, Type renderableType)
        {
            rendererImplementations = Assembly.GetAssembly(renderer).GetTypes()
                .Where(a => !a.IsAbstract && a.BaseType == renderableType)
                .Select(a => (BaseRenderable)Activator.CreateInstance(a)).ToList();
        }

        protected List<BaseRenderable> rendererImplementations = new List<BaseRenderable>();

        protected List<BaseRenderable> renderables = new List<BaseRenderable>();

        public void AddRenderable(RenderableTypes renderableType, RenderableProperties properties)
        {
            var implementation = rendererImplementations.FirstOrDefault(a => renderableType == a.RenderableType);

            if (implementation == null)
            {
                return;
            }
            
            implementation.Initialize(properties);

            renderables.Add(implementation);
        }
    }
}