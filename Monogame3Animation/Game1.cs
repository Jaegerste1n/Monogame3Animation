using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame3Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleCreamTexture, tribbleOrangeTexture, tribbleBrownTexture, tribbleGreyTexture;
        Rectangle window = new Rectangle(0, 0, 800, 600);
        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleOrangeRect, tribbleBrownRect;
        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleOrangeSpeed, tribbleBrownSpeed;
        SoundEffect tribbleCoo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(50, 50);
            tribbleOrangeRect = new Rectangle(300, 10, 100, 100);
            tribbleOrangeSpeed = new Vector2(0, 2);
            tribbleCreamRect = new Rectangle(200, 50, 100, 100);
            tribbleCreamSpeed = new Vector2(70, 0);
            tribbleBrownRect = new Rectangle(300, 10, 100, 100);
            tribbleBrownSpeed = new Vector2(45, 15);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                tribbleCoo.Play();
            }
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
            }
            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
            }
            if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
            }
            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -1;
                tribbleCoo.Play();
            }
            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
            }
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleCoo.Play();
            }
            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
            {
                tribbleBrownSpeed.Y *= -1;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
