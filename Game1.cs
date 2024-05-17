using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Timers;

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

        Color bgColor, backgroundMask;

        Texture2D magpieIntro;
        SpriteFont gameFont;

        List<Texture2D> magpieAnim;

        Rectangle window, magpieLocation, magpieLocation2;

        MouseState mouseState;
        KeyboardState keyboardState;
        Screen _screen;

        int frame, dialogue;

        string explanation;

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
            backgroundMask = Color.Transparent;

            frame = 0;
            _screen = Screen.Intro;
            dialogue = 0;

            explanation = "This is Magpie. (Click Z to advance dialogue.)";

            mouseState = Mouse.GetState();
            timer = 0f;

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
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

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
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= 0.5)
                {
                    frame += 1;
                    timer = 0;
                    if (frame >= magpieAnim.Count)
                    {
                        frame = 0;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    dialogue += 1;
                    if (dialogue == 1)
                    {
                        explanation = "Magpie is a robot.";
                    }
                    else if (dialogue == 2)
                    {
                        explanation = "They were created to combat destruction,";
                    }
                    else if (dialogue == 3)
                    {
                        explanation = "And to restore life back to an old forest.";
                    }
                    else if (dialogue == 4)
                    {
                        explanation = "If they aren't fighting corrupted creatures,";
                    }
                    else if (dialogue == 5)
                    {
                        explanation = "They're solving puzzles and talking to the forest spirits.";
                    }
                    else if (dialogue == 6)
                    {
                        explanation = "In a weird way, this is a teaser for what I want to do with my final project.";
                    }
                    else if (dialogue == 7)
                    {
                        explanation = "(Press M1.)";
                        if (mouseState.LeftButton == ButtonState.Pressed)
                        {
                            _screen = Screen.EndScreen;
                        }
                    }
                }
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
                _spriteBatch.DrawString(gameFont, explanation, new Vector2(200, 100), Color.White);
            }
            else if (_screen == Screen.EndScreen)
            {
                _spriteBatch.Draw(magpieIntro, magpieLocation, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}