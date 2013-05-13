using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using YaSaog.Entities.Menu;

namespace YaSaog.Scenes {

    public class MenuScene : BaseScene {

        public override void Init() {
            base.Init();

            Manager.FadeInSong(Assets.Menu, true, 0.5f);

            Manager.Game.IsMouseVisible = true;

            var mainMenu = new List<MenuButton>();
            
            var play = new MenuButton(0, 0, "Play", () => { Manager.SwitchScene(new LevelSelectionScene()); });
            mainMenu.Add(play);

            var credits = new MenuButton(0, 0, "Credits", () => { Manager.SwitchScene(new CreditsScene()); });
            mainMenu.Add(credits);

            var exit = new MenuButton(0, 0, "Exit", () => { Manager.Game.Exit(); });
            mainMenu.Add(exit);

            LoadMenu(mainMenu);
        }

        public void LoadMenu(List<MenuButton> buttons) {
            foreach (var but in Entities.Where(but => but.CollisionType == "menubutton")) {
                RemoveEntity(but);
            }

            for (int i = 0; i < buttons.Count; i++) {
                var button = buttons[i];
                var pos = new Vector2((MainGame.Width / 2) - button.Size.X / 2, (MainGame.Height / 2) + (button.Size.Y + 75 * i));
                button.Position = pos;

                AddEntity(button);
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.MenuBackground, new Rectangle(0, 0, MainGame.Width, MainGame.Height), Color.White);

            spriteBatch.Draw(Assets.Logo, new Rectangle((MainGame.Width / 2) - 382 / 2, (MainGame.Height / 2) - 200, 382, 91), Color.White);
            
            base.Draw(spriteBatch);
        }

    }
}
