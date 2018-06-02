﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Renderer.Base;

namespace MODEXngine.lib.Base
{
    public abstract class BaseRenderer
    {
        protected string GameTitle;
        protected Settings Settings;

        public event EventHandler WindowClosed;

        protected void OnWindowClosed()
        {
            WindowClosed?.Invoke(this, null);
        }

        public void SetGameLaunchItems(string gameTitle, Settings settings)
        {
            this.GameTitle = gameTitle;
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

        public void AddRenderable(BaseRenderable renderable)
        {
            var implementation = rendererImplementations.FirstOrDefault(a => renderable.GetType() == a.BaseObject);

            if (implementation == null)
            {
                return;
            }
            
            implementation.Initialize(renderable);

            renderables.Add(implementation);
        }
    }
}