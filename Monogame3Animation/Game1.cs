using System;
using System.Threading;
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
        Texture2D tribbleCreamTexture, tribbleOrangeTexture, tribbleBrownTexture, tribbleGreyTexture, barricadedDoorTexture, houseTexture;
        Rectangle window = new Rectangle(0, 0, 800, 600);
        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleOrangeRect, tribbleBrownRect, backDrop;
        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleOrangeSpeed, tribbleBrownSpeed;
        SoundEffect tribbleCoo;
        Random generator = new Random();
        

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
            _graphics.ApplyChanges();
            tribbleGreyRect = new Rectangle(generator.Next(0,500), generator.Next(0,500), 100, 100);
            tribbleGreySpeed = new Vector2(40, 40);
            tribbleOrangeRect = new Rectangle(generator.Next(0, 500), generator.Next(0, 500), 100, 100);
            tribbleOrangeSpeed = new Vector2(0, 2);
            tribbleCreamRect = new Rectangle(generator.Next(0, 500), generator.Next(0, 500), 100, 100);
            tribbleCreamSpeed = new Vector2(50, 0);
            tribbleBrownRect = new Rectangle(generator.Next(0, 500), generator.Next(0, 500), 100, 100);
            tribbleBrownSpeed = new Vector2(40, 20);
            backDrop = new Rectangle(0, 0, 800, 600);




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
            barricadedDoorTexture = Content.Load<Texture2D>("barricadedDoor");
            houseTexture = Content.Load<Texture2D>("house");

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
            int rng = new Random().Next(1, 15);
            
            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
            {
                tribbleGreyRect.X = -1;
                tribbleCoo.Play();
                int coinflipG = new Random().Next(1, 3);
                if (coinflipG == 1)
                {
                    tribbleGreyRect.Width = (tribbleGreyRect.Width + rng + 1);
                    tribbleGreyRect.Height = (tribbleGreyRect.Height + rng + 1);
                }
                if (coinflipG == 2)
                {
                    tribbleGreyRect.Width = (tribbleGreyRect.Width - rng);
                    tribbleGreyRect.Height = (tribbleGreyRect.Height - rng);
                }
                
            }
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
            {
                tribbleGreyRect.Y = -1;
                int coinflipG = new Random().Next(1, 3);
                if (coinflipG == 1)
                {
                    tribbleGreyRect.Width = (tribbleGreyRect.Width + rng + 1);
                    tribbleGreyRect.Height = (tribbleGreyRect.Height + rng + 1);
                }
                if (coinflipG == 2)
                {
                    tribbleGreyRect.Width = (tribbleGreyRect.Width - rng);
                    tribbleGreyRect.Height = (tribbleGreyRect.Height - rng);
                }
            }
            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
                int coinflipC = new Random().Next(1, 3);
                if (coinflipC == 1)
                {
                    tribbleCreamRect.Width = (tribbleCreamRect.Width + rng +1);
                    tribbleCreamRect.Height = (tribbleCreamRect.Height + rng +1);
                }
                if (coinflipC == 2)
                {
                    tribbleCreamRect.Width = (tribbleCreamRect.Width - rng);
                    tribbleCreamRect.Height = (tribbleCreamRect.Height - rng);
                }
            }
            if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
                int coinflipC = new Random().Next(1, 3);
                if (coinflipC == 1)
                {
                    tribbleCreamRect.Width = (tribbleCreamRect.Width + rng +1);
                    tribbleCreamRect.Height = (tribbleCreamRect.Height + rng +1);
                }
                if (coinflipC == 2)
                {
                    tribbleCreamRect.Width = (tribbleCreamRect.Width - rng);
                    tribbleCreamRect.Height = (tribbleCreamRect.Height - rng);
                }
            }
            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
            {
                tribbleOrangeRect.X = generator.Next(0, 20);
                tribbleOrangeRect.Y = -generator.Next(0, 20);
                tribbleCoo.Play();
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
                int coinflipO = new Random().Next(1, 3);
                if (coinflipO == 1)
                {
                    tribbleOrangeRect.Width = (tribbleOrangeRect.Width + rng +1);
                    tribbleOrangeRect.Height = (tribbleOrangeRect.Height + rng +1);
                }
                if (coinflipO == 2)
                {
                    tribbleOrangeRect.Width = (tribbleOrangeRect.Width - rng);
                    tribbleOrangeRect.Height = (tribbleOrangeRect.Height - rng);
                }
            }
            if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeRect.Y = -generator.Next(0, 20);
                tribbleOrangeRect.X = generator.Next(0, 20);
                int coinflipO = new Random().Next(1, 3);
                if (coinflipO == 1)
                {
                    tribbleOrangeRect.Width = (tribbleOrangeRect.Width + rng +1);
                    tribbleOrangeRect.Height = (tribbleOrangeRect.Height + rng +1);
                }
                if (coinflipO == 2)
                {
                    tribbleOrangeRect.Width = (tribbleOrangeRect.Width - rng);
                    tribbleOrangeRect.Height = (tribbleOrangeRect.Height - rng);
                }
            }
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleCoo.Play();
                int coinflipB = new Random().Next(1, 3);
                if (coinflipB == 1)
                {
                    tribbleBrownRect.Width = (tribbleBrownRect.Width + rng +1);
                    tribbleBrownRect.Height = (tribbleBrownRect.Height + rng +1);
                }
                if (coinflipB == 2)
                {
                    tribbleBrownRect.Width = (tribbleBrownRect.Width - rng);
                    tribbleBrownRect.Height = (tribbleBrownRect.Height - rng);
                }
            }
            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
            {
                tribbleBrownSpeed.Y *= -1;
                int coinflipB = new Random().Next(1, 3);
                if (coinflipB == 1)
                {
                    tribbleBrownRect.Width = (tribbleBrownRect.Width + rng + 1);
                    tribbleBrownRect.Height = (tribbleBrownRect.Height + rng + 1);
                }
                if (coinflipB == 2)
                {
                    tribbleBrownRect.Width = (tribbleBrownRect.Width - rng);
                    tribbleBrownRect.Height = (tribbleBrownRect.Height - rng);
                }
            }
            


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(barricadedDoorTexture, backDrop, Color.White);
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
