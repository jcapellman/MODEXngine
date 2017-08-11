using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using MODEXngine.Library.Engine.Common;
using MODEXngine.Library.Engine.GameStates;
using MODEXngine.Library.Engine.Managers;
using MODEXngine.Library.Engine.Objects.Common;

namespace MODEXngine.Library.Engine
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        private SpriteBatch _spriteBatch;
        
        private BaseGameState _currentGameState;

        private GameStateContainer _gsContainer;

        private readonly GraphicsDeviceManager _graphics;

        private readonly Type _initialGameState;

        private readonly string _windowTitle;

        public MainGame(string windowTitle, Type initialGameState)
        {
            _windowTitle = windowTitle;

            _initialGameState = initialGameState;

            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreparingDeviceSettings += _graphics_PreparingDeviceSettings;
            
            Content.RootDirectory = "Content";
        }
        
        private void _graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
#if DEBUG
            _graphics.IsFullScreen = false;
#else
            _graphics.IsFullScreen = true;
#endif
            _graphics.PreferredBackBufferWidth = Constants.RESOLUTION_WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.RESOLUTION_HEIGHT;
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            _graphics.PreferMultiSampling = true;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;            
        }

        protected override void Initialize()
        {
            Window.Title = _windowTitle;

            _gsContainer = new GameStateContainer
            {
                Window_Height = Window.ClientBounds.Height,
                Window_Width = Window.ClientBounds.Width,
                TManager = new TextureManager(Content),
                MainFont = Content.Load<SpriteFont>("Main")
            };
            
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentGameState = (BaseGameState)Activator.CreateInstance(_initialGameState, _gsContainer);

            _currentGameState.OnRequestStateChange += CurrentGameState_OnRequestStateChange;
            _currentGameState.LoadContent();
        }

        private void CurrentGameState_OnRequestStateChange(object sender, BaseGameState e)
        {
            _currentGameState = e;

            _currentGameState.LoadContent();
        }
        
        protected override void Update(GameTime gameTime)
        {
            _currentGameState.HandleInput(GamePad.GetState(PlayerIndex.One), Keyboard.GetState(), TouchPanel.GetState());
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _currentGameState.Render(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}