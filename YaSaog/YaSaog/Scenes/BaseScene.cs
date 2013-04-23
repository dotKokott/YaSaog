using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Entities;
using YaSaog.Utils.ActionLists;
using YaSaog.Utils.Coroutines;

namespace YaSaog.Scenes {

    public abstract class BaseScene {

        public bool Inited { get; private set; }

        public SceneManager Manager { get; set; }       
        
        public ActionList Actions = new ActionList();
        public Coroutines Coroutines = new Coroutines();
        public List<BaseEntity> Entities = new List<BaseEntity>();

        public BaseScene() {            
            Inited = false;
        }

        public void AddEntity(BaseEntity entity) {
            Entities.Add(entity);
            entity.Screen = this;

            entity.Init();
        }

        public void RemoveEntity(BaseEntity entity) {
            if (!Entities.Contains(entity))
                return;

            entity.Delete();
            Entities.Remove(entity);
        }

        public virtual void Init() {                       
            Inited = true;
        }

        public virtual void Update(GameTime gameTime) {         
            //Dirty? Calling ToArray to make a copy of the entity collection preventing crashing when entities create other entities through an update call
            foreach (var ent in Entities.ToArray()) {
                ent.Update(gameTime);
            }            

            Actions.Update(gameTime);
            Coroutines.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            foreach (var ent in Entities.ToArray().OrderBy(e => e.ZDepth)) {
                ent.Draw(spriteBatch);
            }
        }
    }
}
