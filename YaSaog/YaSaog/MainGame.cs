using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YaSaog {

    public class MainGame : Game {

        private ExtendedSpriteBatch spriteBatch;
        private readonly Rectangle viewPortRectangle;
        private Matrix spriteScale;        
        
        public GraphicsDeviceManager graphics;
        public static int Width = 1280;
        public static int Height = 800;
        public bool IsFullScreen = false;

        //public ScreenManager ScreenManager;
        
        public MainGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.SynchronizeWithVerticalRetrace = false;
            this.viewPortRectangle = new Rectangle(0, 0, Width, Height);

            graphics.IsFullScreen = IsFullScreen;
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new ExtendedSpriteBatch(GraphicsDevice);
            Assets.LoadContent(Content);

            float scaleX = graphics.GraphicsDevice.Viewport.Width / Width;
            float scaleY = graphics.GraphicsDevice.Viewport.Height / Height;

            spriteScale = Matrix.CreateScale(scaleX, scaleY, 1);
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);






            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
