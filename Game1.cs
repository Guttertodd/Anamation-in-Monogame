using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Anamation_in_Monogame
{
    enum Screen
    {
        Intro,
        TribbleYard,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        SoundEffect tribbleSound;

        Texture2D greyTribbleTexture, brownTribbleTexture, creamTribbleTexture, orangeTribbleTexture, introTexture;
        Rectangle greyTribbleRect, brownTribbleRect, creamTribbleRect, orangeTribbleRect;
        Vector2 greyTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed, orangeTribbleSpeed;
        Color greyTribble, brownTribble, creamTribble, orangeTribble;

        
        Screen screen;

        MouseState mouseState;

        Color backgroundColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            backgroundColor = Color.CornflowerBlue;
            // TODO: Add your initialization logic here
            greyTribbleRect = new Rectangle(150, 100, 100, 100);
            greyTribbleSpeed = new Vector2(2, 2);

            brownTribbleRect = new Rectangle(100, 100, 100, 100);
            brownTribbleSpeed = new Vector2(2, 2);

            creamTribbleRect = new Rectangle(10,50,100,100);
            creamTribbleSpeed = new Vector2(2, 2);

            orangeTribbleRect = new Rectangle(300, 125, 100, 100);
            orangeTribbleSpeed = new Vector2(2, 2);

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTribbleTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTribbleTexture = Content.Load<Texture2D>("tribbleOrange");
            introTexture = Content.Load<Texture2D>("Untitled");
            tribbleSound = Content.Load<SoundEffect>("");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                greyTribbleRect.X += (int)greyTribbleSpeed.X;
                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                {
                    greyTribbleSpeed.X *= -1;
                    backgroundColor = new Color(255, 255, 100);
                }

                brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
                if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
                {
                    brownTribbleSpeed.Y *= -1;
                    backgroundColor = new Color(255, 128, 128);
                }

                creamTribbleRect.Y += (int)creamTribbleSpeed.Y;
                if (creamTribbleRect.Bottom > window.Height || creamTribbleRect.Top < 0)
                {
                    creamTribbleSpeed.Y *= -1;
                    backgroundColor = new Color(203, 195, 227);
                }

                creamTribbleRect.X += (int)creamTribbleSpeed.X;
                if (creamTribbleRect.Right > window.Width || creamTribbleRect.Left < 0)
                {
                    creamTribbleSpeed.X *= -1;

                }
                orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
                if (orangeTribbleRect.Bottom > window.Height || orangeTribbleRect.Top < 0)
                {
                    orangeTribbleSpeed.Y *= -1;

                }

                orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
                if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.Left < 0)
                {
                    orangeTribbleSpeed.X *= -1;
                    backgroundColor = new Color(19, 230, 59);
                }
            }
            //greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            //if (greyTribbleRect.Top > window.Height || greyTribbleRect.Bottom < 0)
            //    greyTribbleSpeed.Y *= -1;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(greyTribbleTexture, greyTribbleRect, Color.White);
                _spriteBatch.Draw(brownTribbleTexture, brownTribbleRect, Color.White);
                _spriteBatch.Draw(creamTribbleTexture, creamTribbleRect, Color.White);
                _spriteBatch.Draw(orangeTribbleTexture, orangeTribbleRect, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
