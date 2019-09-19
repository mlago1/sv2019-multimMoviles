using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

public class GameScreen
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    Texture2D background, spaceship, enemy;
    private Vector2 shipPosition;
    float shipSpeed = 200;
    private Vector2 enemyPosition;
    private Vector2 enemySpeed;
    private SpriteFont myFont;
    private Song music;
    private SoundEffect fireSound;

    public GameScreen(int maxX, int maxY)
    {
        shipPosition = new Vector2(470, 500);
        enemyPosition = new Vector2(300, 150);
        enemySpeed = new Vector2(200, 100);
    }

    public void LoadContent(ContentManager Content)
    {
        background = Content.Load<Texture2D>("fondo960");
        spaceship = Content.Load<Texture2D>("nave");
        enemy = Content.Load<Texture2D>("enemigo1a");
        myFont = Content.Load<SpriteFont>("Font8bit");
        fireSound = Content.Load<SoundEffect>("fire");
        music = Content.Load<Song>("levelTick");

        MediaPlayer.Play(music);
        MediaPlayer.IsRepeating = true;
    }

    public void Update(GameTime gameTime)
    {
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

        // Collisions checking
        if (new Rectangle((int)shipPosition.X, (int)shipPosition.Y,
            spaceship.Width, spaceship.Height).Intersects(
            new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y,
            enemy.Width, enemy.Height)))
            //Exit()
            // TO DO: Real collision logic
            ;

        // Fire (only sound so far)
        if (keyboardState.IsKeyDown(Keys.Space))
            fireSound.CreateInstance().Play();
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(background,
            new Rectangle(0, 0, 960, 600),
            Color.White);
        spriteBatch.DrawString(myFont, "Some text",
            new Vector2(420, 10), Color.Cyan);
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
    }
}

