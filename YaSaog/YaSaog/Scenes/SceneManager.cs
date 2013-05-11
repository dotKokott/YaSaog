using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using YaSaog.Utils.ActionLists;
using Microsoft.Xna.Framework.Media;
using YaSaog.Utils.ActionLists.Actions;

namespace YaSaog.Scenes {

    public class SceneManager {

        private List<BaseScene> Scenes = new List<BaseScene>();

        public MainGame Game { get; private set; }
        public ActionList Actions = new ActionList();        

        public BaseScene TopScene {
            get {
                return Scenes.Last();
            }
        }        

        public SceneManager(MainGame game) {
            Game = game;
        }

        public void AddScene(BaseScene scene) {
            Scenes.Add(scene);
            scene.Manager = this;
            
            if (!scene.Inited)
                scene.Init();            
        }

        public void RemoveScene(BaseScene scene) {
            Scenes.Remove(scene);
        }

        public void SwitchScene(BaseScene scene) {
            Scenes.Clear();
            AddScene(scene);
        }

        public void FadeInSong(Song song, bool repeat, float maxVolume) {
            Actions.AddAction(new FadeInSong(song, repeat, maxVolume), true);
        }

        public void Update(GameTime gameTime) {
            Actions.Update(gameTime);
            Scenes.Last().Update(gameTime);
        }

        public void Draw(ExtendedSpriteBatch spriteBatch) {
            foreach (var scene in Scenes) {
                scene.Draw(spriteBatch);
            }
        }        
    }
}
