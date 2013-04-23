using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YaSaog.Entities;

namespace YaSaog.Scenes {
    public class GameScene : BaseScene {

        public override void Init() {
            base.Init();

            AddEntity(new Bubble(50, 50));
        }
    }
}
