using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Summative_Animation
{
    enum Screen
    {
        Intro,
        MainScreen,
        EndScreen
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Color bgColor;

        Texture2D magpieIntro;
        SpriteFont gameFont;

        List<Texture2D> magpieAnim;

        Rectangle window, magpieLocation, magpieLocation2;

        MouseState mouseState;
        Screen _screen;

        int frame;
        float timer;
        bool placeholder;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            magpieAnim = new List<Texture2D>();
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;

            bgColor = Color.LightSkyBlue;

            frame = 0;
            _screen = Screen.Intro;

            mouseState = Mouse.GetState();

            magpieLocation = new Rectangle(0, 200, 240, 240);
            magpieLocation2 = new Rectangle(300, 150, 120, 120);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            gameFont = Content.Load<SpriteFont>("gameFont");
            magpieIntro = Content.Load<Texture2D>("magpieStill");

            magpieAnim.Add(Content.Load<Texture2D>("frame0"));
            magpieAnim.Add(Content.Load<Texture2D>("frame1"));
            magpieAnim.Add(Content.Load<Texture2D>("frame2"));
            magpieAnim.Add(Content.Load<Texture2D>("frame3"));
            magpieAnim.Add(Content.Load<Texture2D>("frame4"));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (_screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _screen = Screen.MainScreen;
                }
            }
            else if (_screen == Screen.MainScreen) 
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            if (_screen == Screen.Intro)
            {
                _spriteBatch.Draw(magpieIntro, magpieLocation, Color.White);
                _spriteBatch.DrawString(gameFont, "Halocene: Pre-Alpha Build", new Vector2(400, 250), Color.White);
                _spriteBatch.DrawString(gameFont, "Click M1 to play", new Vector2(450, 300), Color.White);
            }
            else if (_screen == Screen.MainScreen)
            {
                _spriteBatch.Draw(magpieAnim[frame], magpieLocation2, Color.White);
                _spriteBatch.DrawString(gameFont, "WIP...", new Vector2(200, 200), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}