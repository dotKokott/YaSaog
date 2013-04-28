using Microsoft.Xna.Framework;

namespace YaSaog.Entities.Collision {

    public class CircleCollider : BaseCollider {

        public int Radius { get; set; }

        public CircleCollider(BaseEntity parent, string name, int radius)
            : base(parent, ColliderType.Rectangle, name) {

                Radius = radius;
        }

        public override bool CollideWithRectangle(RectangleCollider with) {
            throw new System.NotImplementedException();
        }

        public override bool CollideWithCircle(CircleCollider with) {
            throw new System.NotImplementedException();
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {            
        }
    }
}
