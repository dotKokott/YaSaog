using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using YaSaog.Scenes;
using YaSaog.Utils.ActionLists;
using YaSaog.Utils.Coroutines;

namespace YaSaog.Entities {

    public abstract class BaseEntity {

        public ActionList Actions = new ActionList();
        public Coroutines Coroutines = new Coroutines();

        public Vector2 Size { get; set; }
        public Vector2 Offset { get; set; }

        public BaseScene Scene { get; set; }

        public bool Collidable = true;
        public string CollisionType { get; set; }

        public int ZDepth = 1;

        public float X { get; set; }
        public float Y { get; set; }

        public Vector2 Position {
            get {
                return new Vector2(X, Y);
            }
            set {
                X = (int)value.X;
                Y = (int)value.Y;
            }
        }

        public Rectangle BoundingBox {
            get {
                return new Rectangle((int)X + (int)Offset.X, (int)Y + (int)Offset.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public IEnumerable<BaseEntity> GetCollidingEntities(string type) {
            return (from ent in Scene.Entities where ent.Collidable && ent.CollisionType == type && ent.BoundingBox.Intersects(BoundingBox) select ent).ToArray();
        }

        public BaseEntity GetFirstCollidingEntity(string type) {
            return GetCollidingEntities(type).FirstOrDefault();
        }

        //Empty constructor for EntityFactory reflection
        public BaseEntity() { }

        public abstract void Init();

        public virtual void Update(GameTime gameTime) {
            Actions.Update(gameTime);
            Coroutines.Update();
        }

        public abstract void Draw(ExtendedSpriteBatch spriteBatch);
        public abstract void Delete();
    }
}
