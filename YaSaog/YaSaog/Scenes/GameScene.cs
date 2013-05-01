using YaSaog.Entities;

namespace YaSaog.Scenes {

    public class GameScene : BaseScene {

        public override void Init() {
            base.Init();

            AddEntity(new Level(Assets.TestLevel));
        }        
    }
}
