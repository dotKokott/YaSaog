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

        public override void Init() {
            base.Init();

            AddEntity(new Level(Assets.TestLevel));

            AddEntity(new Star(100, 100));

            InitialStarCount = StarCount;
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(Assets.UIFont, string.Format("{0} / {1} Stars", (InitialStarCount - StarCount).ToString(), InitialStarCount.ToString()), new Vector2(1000, 10), Color.Yellow);
        }
    }
}
