using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using YaSaog.Entities.Menu;

namespace YaSaog.Scenes {

    public class LevelSelectionScene : BaseScene {

        public override void Init() {
            base.Init();

            var startPosX = 300;
            var startPosY = 150;

            var posX = startPosX;
            var posY = startPosY;
            for (int i = 0; i < Assets.Levels.Count; i++) {
                var level = Assets.Levels[i];

                var lvlButton = new LevelButton(0, 0, (i + 1).ToString(), () => { Manager.SwitchScene(new GameScene(level)); });

                posX += (int)lvlButton.Size.X + 100;
                if (i % 5 == 0) {
                    posX = startPosX;
                    posY += (int)lvlButton.Size.Y + 50;
                }

                lvlButton.Position = new Vector2(posX, posY);               

                AddEntity(lvlButton);
            }

            var back = new MenuButton(30, MainGame.Height - 80, "Back", () => { Manager.SwitchScene(new MenuScene()); });
            AddEntity(back);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Manager.NewKeyboardState.IsKeyDown(Keys.Escape)) {
                Manager.SwitchScene(new MenuScene());
            }
        }
    }
}