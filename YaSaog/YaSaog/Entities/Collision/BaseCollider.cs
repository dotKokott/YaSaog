using Microsoft.Xna.Framework;
namespace YaSaog.Entities.Collision {

    public abstract class BaseCollider {

        public BaseEntity Parent { get; set; }
        public Vector2 Offset { get; set; }
        public ColliderType Type { get; set; }
        public string Name { get; set; }

        public BaseCollider(BaseEntity parent, ColliderType type, string name) {
            Parent = parent;
            Type = type;
            Name = name;
        }

        public abstract bool CollideWithRectangle(RectangleCollider with);
        public abstract bool CollideWithCircle(CircleCollider with);

        public abstract void Draw(ExtendedSpriteBatch spriteBatch);
    }
}
