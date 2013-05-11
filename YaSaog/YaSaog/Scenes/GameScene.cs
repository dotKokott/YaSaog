using System.Linq;
using YaSaog.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using Microsoft.Xna.Framework.Media;

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

            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                this.Manager.SwitchScene(new MenuScene());
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(Assets.UI, string.Format("{0} / {1} Stars", CollectedStarCount.ToString(), InitialStarCount.ToString()), new Vector2(1000, 10), Color.Yellow);

            spriteBatch.DrawString(Assets.UI, ((int)Time).ToString("000 s"), new Vector2(800, 10), Color.Yellow);
        }
    }
}
