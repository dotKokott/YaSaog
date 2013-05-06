using System.Linq;
using YaSaog.Entities;
using Microsoft.Xna.Framework;

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

            AddEntity(new Level(Assets.TestLevel));

            InitialStarCount = StarCount;

            Time = 0f;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(Assets.UIFont, string.Format("{0} / {1} Stars", (InitialStarCount - StarCount).ToString(), InitialStarCount.ToString()), new Vector2(1000, 10), Color.Yellow);

            spriteBatch.DrawString(Assets.UIFont, ((int)Time).ToString("000 s"), new Vector2(800, 10), Color.Yellow);
        }
    }
}
