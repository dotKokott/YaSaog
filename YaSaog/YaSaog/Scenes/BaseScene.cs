using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Entities;
using YaSaog.Utils.ActionLists;

namespace YaSaog.Scenes {

    public abstract class BaseScene {

        public bool Inited { get; private set; }

        public SceneManager Manager { get; set; }       
        
        public ActionList Actions = new ActionList();
        public List<BaseEntity> Entities = new List<BaseEntity>();

        public BaseScene() {            
            Inited = false;
        }

        public void AddEntity(BaseEntity entity) {            
            if (entity == null) return;

            Entities.Add(entity);
            entity.Scene = this;

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
        }

        public virtual void Draw(ExtendedSpriteBatch spriteBatch) {
            foreach (var ent in Entities.ToArray().OrderBy(e => e.ZDepth)) {
                ent.Draw(spriteBatch);
            }
        }
    }
}
