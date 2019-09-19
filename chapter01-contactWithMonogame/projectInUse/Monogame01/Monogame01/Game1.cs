using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame01
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background, spaceship;
        private Vector2 shipPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Screen size: 960x600
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            shipPosition = new Vector2(470, 500);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("fondo960");
            spaceship = Content.Load<Texture2D>("nave");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                shipPosition.X -= 5;
            if (keyboardState.IsKeyDown(Keys.Right))
                shipPosition.X += 5;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background,
                new Rectangle(0, 0, 960, 600),
                Color.White);
            spriteBatch.Draw(spaceship,
               new Rectangle(
                   (int)shipPosition.X, (int)shipPosition.Y,
                   spaceship.Width, spaceship.Height),
                   Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
