using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YaSaog.Scenes;

namespace YaSaog {

    public class MainGame : Game {

        private ExtendedSpriteBatch spriteBatch;
        private readonly Rectangle viewPortRectangle;
        private Matrix spriteScale;

        private DebugComponent debugComponent;
        
        public GraphicsDeviceManager graphics;
        public static int Width = 1280;
        public static int Height = 800;
        public bool IsFullScreen = false;

        public SceneManager SceneManager;
        
        public MainGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.SynchronizeWithVerticalRetrace = true;
            this.viewPortRectangle = new Rectangle(0, 0, Width, Height);

            graphics.IsFullScreen = IsFullScreen;            
        }

        protected override void Initialize() {
            base.Initialize();

            debugComponent = new DebugComponent(this);

            SceneManager.AddScene(new MenuScene());
        }

        protected override void LoadContent() {
            spriteBatch = new ExtendedSpriteBatch(GraphicsDevice);
            Assets.LoadContent(Content);

            SceneManager = new SceneManager(this);

            float scaleX = graphics.GraphicsDevice.Viewport.Width / Width;
            float scaleY = graphics.GraphicsDevice.Viewport.Height / Height;

            spriteScale = Matrix.CreateScale(scaleX, scaleY, 1);
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            SceneManager.Update(gameTime);

            debugComponent.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, spriteScale);

            SceneManager.Draw(spriteBatch);

            debugComponent.Draw(spriteBatch, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
