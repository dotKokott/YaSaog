using Microsoft.Xna.Framework;

namespace YaSaog.Entities.Collision {

    public class RectangleCollider : BaseCollider {

        public Vector2 Size { get; set; }

        public Rectangle BoundingBox {
            get {
                return new Rectangle((int)Parent.X + (int)Offset.X, (int)Parent.Y + (int)Offset.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public RectangleCollider(BaseEntity parent, string name, Vector2 size)
            : base(parent, ColliderType.Rectangle, name) {

                Size = size;
        }

        public override bool CollideWithRectangle(RectangleCollider with) {
            return BoundingBox.Intersects(with.BoundingBox);
        }

        public override bool CollideWithCircle(CircleCollider with) {
            return false;
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.DrawRectangle(BoundingBox, Color.Red);
        }
    }
}
