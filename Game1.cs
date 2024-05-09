using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        Texture2D magpieIntro, magpieAnim;
        SpriteFont gameFont;

        Rectangle window, magpieLocation, magpieLocation2;

        MouseState mouseState;

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

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.PreferredBackBufferWidth = window.Width;

            bgColor = Color.LightSkyBlue;

            frame = 0;

            mouseState = Mouse.GetState();

            magpieLocation = new Rectangle(0, 200, 120, 120);
            magpieLocation2 = new Rectangle(300, 150, 120, 120);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            gameFont = Content.Load<SpriteFont>("gameFont");
            magpieIntro = Content.Load<Texture2D>("magpieStill");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(magpieIntro, magpieLocation, Color.White);
            _spriteBatch.DrawString(gameFont, "testing...", new Vector2(400, 250), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}