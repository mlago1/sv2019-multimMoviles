using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame01
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background, spaceship, enemy;
        private Vector2 shipPosition;
        float shipSpeed = 200;
        private Vector2 enemyPosition;
        private Vector2 enemySpeed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Screen size: 960x600
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            shipPosition = new Vector2(470, 500);
            enemyPosition = new Vector2(300, 150);
            enemySpeed = new Vector2(200, 100);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("fondo960");
            spaceship = Content.Load<Texture2D>("nave");
            enemy = Content.Load<Texture2D>("enemigo1a");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Spaceship movement, using keyboard
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                shipPosition.X -= shipSpeed *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Right))
                shipPosition.X += shipSpeed *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Enemy movement, automatic
            enemyPosition.X += enemySpeed.X *
                (float)gameTime.ElapsedGameTime.TotalSeconds;
            enemyPosition.Y += enemySpeed.Y *
                (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((enemyPosition.X < 20) || (enemyPosition.X > 850))
                enemySpeed.X = -enemySpeed.X;
            if ((enemyPosition.Y < 20) || (enemyPosition.Y > 550))
                enemySpeed.Y = -enemySpeed.Y;

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
            spriteBatch.Draw(enemy,
               new Rectangle(
                   (int)enemyPosition.X, (int)enemyPosition.Y,
                   enemy.Width, enemy.Height),
                   Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
