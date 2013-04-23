using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using YaSaog.Utils.ActionLists;

namespace YaSaog.Scenes {

    public class SceneManager {

        private List<BaseScene> Screens = new List<BaseScene>();

        public MainGame Game { get; private set; }
        public ActionList Actions = new ActionList();        

        public BaseScene TopScreen {
            get {
                return Screens.Last();
            }
        }        

        public SceneManager(MainGame game) {
            Game = game;
        }

        public void AddScreen(BaseScene screen) {
            Screens.Add(screen);
            screen.Manager = this;
            
            if (!screen.Inited)
                screen.Init();            
        }

        public void RemoveScreen(BaseScene screen) {
            Screens.Remove(screen);
        }

        public void SwitchScreen(BaseScene screen) {
            Screens.Clear();
            AddScreen(screen);
        }

        public void Update(GameTime gameTime) {
            Actions.Update(gameTime);
            Screens.Last().Update(gameTime);
        }

        public void Draw(ExtendedSpriteBatch spriteBatch) {
            foreach (var screen in Screens) {
                screen.Draw(spriteBatch);
            }
        }        
    }
}
