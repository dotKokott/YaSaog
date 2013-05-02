using YaSaog.Entities;
using Microsoft.Xna.Framework;

namespace YaSaog.Scenes {

    public class GameScene : BaseScene {

        public override void Init() {
            base.Init();

            AddEntity(new Level(Assets.TestLevel));
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }
    }
}
