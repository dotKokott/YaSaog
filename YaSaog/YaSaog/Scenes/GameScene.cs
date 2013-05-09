using System.Linq;
using YaSaog.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Scenes {

    public class GameScene : BaseScene {

        public int InitialStarCount { get; set; }
        public int StarCount {
            get {
                return Entities.Where(ent => ent.CollisionType == "star").Count();
            }
        }

        public float Time { get; private set; }

        public override void Init() {
            base.Init();

            for (int i = 0; i < MainGame.Width / 32; i++) {
                AddEntity(new SolidSpike(32 * i, 0));
                AddEntity(new SolidSpike(32 * i, MainGame.Height - 32));
            }

            for (int i = 0; i < MainGame.Height / 32; i++) {
                AddEntity(new SolidSpike(0, 32 * i));
                AddEntity(new SolidSpike(MainGame.Width - 32, 32 * i));
            }

            AddEntity(new Level(Assets.TestLevel));

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

            spriteBatch.DrawString(Assets.UI, string.Format("{0} / {1} Stars", (InitialStarCount - StarCount).ToString(), InitialStarCount.ToString()), new Vector2(1000, 10), Color.Yellow);

            spriteBatch.DrawString(Assets.UI, ((int)Time).ToString("000 s"), new Vector2(800, 10), Color.Yellow);
        }
    }
}
