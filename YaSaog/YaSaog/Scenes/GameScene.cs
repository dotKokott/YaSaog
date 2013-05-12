using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using YaSaog.Entities;

namespace YaSaog.Scenes {

    public class GameScene : BaseScene {

        public int InitialStarCount { get; set; }
        public int StarCount {
            get {
                return Entities.Where(ent => ent.CollisionType == "star").Count();
            }
        }

        public int CollectedStarCount {
            get {
                return InitialStarCount - StarCount;
            }
        }

        public float Time { get; private set; }

        public Level CurrentLevel { get; set; }

        public GameScene(Level level)
            : base() {

                CurrentLevel = level;
        }

        public override void Init() {
            base.Init();

            Manager.FadeInSong(Assets.Ingame, true, 0.2f);

            for (int i = 0; i < MainGame.Width / 32; i++) {
                AddEntity(new SolidSpike(32 * i, 0));
                AddEntity(new SolidSpike(32 * i, MainGame.Height - 32));
            }

            for (int i = 0; i < MainGame.Height / 32; i++) {
                AddEntity(new SolidSpike(0, 32 * i));
                AddEntity(new SolidSpike(MainGame.Width - 32, 32 * i));
            }

            AddEntity(CurrentLevel);

            InitialStarCount = StarCount;

            Time = 0f;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Manager.Game.IsActive) {
                if (Manager.NewMouseState.X < 0)
                    Mouse.SetPosition(0, Manager.NewMouseState.Y);
                if (Manager.NewMouseState.X > MainGame.Width)
                    Mouse.SetPosition(MainGame.Width, Manager.NewMouseState.Y);
                if (Manager.NewMouseState.Y < 0)
                    Mouse.SetPosition(Manager.NewMouseState.X, 0);
                if (Manager.NewMouseState.Y > MainGame.Height)
                    Mouse.SetPosition(Manager.NewMouseState.X, MainGame.Height);
            } else {
                this.Manager.AddScene(new PauseScene());
            }

            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            var oldState = Manager.OldKeyboardState;
            var state = Manager.NewKeyboardState;

            if (state.IsKeyDown(Keys.Escape)) {
                this.Manager.SwitchScene(new MenuScene());
            }

            if (state.IsKeyDown(Keys.R)) {
                this.Manager.SwitchScene(new GameScene(this.CurrentLevel));
            }

            if (!oldState.IsKeyDown(Keys.P) && state.IsKeyDown(Keys.P)) {
                this.Manager.AddScene(new PauseScene());
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.IngameBackground, new Rectangle(0, 0, MainGame.Width, MainGame.Height), Color.White);

            base.Draw(spriteBatch);

            for (int i = 0; i < InitialStarCount; i++) {
                var pos = new Vector2(30 + (i * 32), 10);
                var color = Color.Gray;

                if (i < CollectedStarCount) {
                    color = Color.White;
                }

                spriteBatch.Draw(Assets.Star, new Rectangle((int)pos.X, (int)pos.Y, 45, 45), color);
            }            
        }
    }
}
