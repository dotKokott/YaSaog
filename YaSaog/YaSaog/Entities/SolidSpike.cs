using Microsoft.Xna.Framework;
using YaSaog.Scenes;
namespace YaSaog.Entities {

    public class SolidSpike : BaseEntity {

        public SolidSpike(int posX, int posY) {
            X = posX;
            Y = posY;

            Size = new Vector2(32, 32);
            collidable = true;

            CollisionType = "spike";
        }

        public override void Init() {                        
        }       

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, Color.Red);
        }

        public override void Delete() {            
        }
    }
}
