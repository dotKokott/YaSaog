using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Scenes;
using YaSaog.Utils.ActionLists;
using YaSaog.Utils.Coroutines;

namespace YaSaog.Entities {

    public abstract class BaseEntity {

        public ActionList Actions = new ActionList();
        public Coroutines Coroutines = new Coroutines();

        public Vector2 Size { get; set; }
        public Vector2 Offset { get; set; }

        public BaseScene Screen { get; set; }

        public bool collidable = true;
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
            return (from ent in Screen.Entities where ent.collidable && ent.CollisionType == type && ent.BoundingBox.Intersects(BoundingBox) select ent).ToArray();
        }

        public BaseEntity GetFirstCollidingEntity(string type) {
            return GetCollidingEntities(type).FirstOrDefault();
        }

        public abstract void Init();

        public virtual void Update(GameTime gameTime) {
            Actions.Update(gameTime);
            Coroutines.Update();
        }

        public abstract void Draw(ExtendedSpriteBatch spriteBatch);
        public abstract void Delete();
    }
}
