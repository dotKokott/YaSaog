using YaSaog.Entities;

namespace YaSaog.Scenes {

    public class GameScene : BaseScene {

        public override void Init() {
            base.Init();

            var bubble = new Bubble(300, 50);
            var dryer = new BlowDryer();
            dryer.Target = bubble;

            AddEntity(bubble);
            AddEntity(dryer);
        }
    }
}
