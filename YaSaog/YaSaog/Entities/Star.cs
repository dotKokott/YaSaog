using Microsoft.Xna.Framework;

namespace YaSaog.Entities {

    public class Star : BaseEntity {

        public Star() : this(0, 0) { }

        public Star(int posX, int posY) {
            X = posX;
            Y = posY;
    
            Size = new Vector2(32, 32);
        
            collidable = true;
            CollisionType = "star";      
        }

        public override void Init() {			
        }

        public void Collect() {
            Screen.RemoveEntity(this);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, Color.Green);
        }

        public override void Delete() {			
        }
    }
}