
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class ScreenManager : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    
    WelcomeScreen welcome;
    GameScreen game;

    public enum MODE { WELCOME, GAME };
    public MODE currentMode { get; set; }

    public ScreenManager()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        game = new GameScreen(960, 600);
        welcome = new WelcomeScreen(this);

        currentMode = MODE.WELCOME;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = 960;
        graphics.PreferredBackBufferHeight = 600;
        graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        game.LoadContent(Content);
        welcome.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        if (Keyboard.GetState().IsKeyDown(Keys.F8))
        {
            graphics.IsFullScreen = !graphics.IsFullScreen;
            graphics.ApplyChanges();
        }

        switch (currentMode)
        {
            case MODE.GAME: game.Update(gameTime); break;
            case MODE.WELCOME: welcome.Update(gameTime); break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        spriteBatch.Begin();

        switch (currentMode)
        {
            case MODE.GAME: game.Draw(gameTime, spriteBatch); break;
            case MODE.WELCOME: welcome.Draw(gameTime, spriteBatch); break;
        }

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
