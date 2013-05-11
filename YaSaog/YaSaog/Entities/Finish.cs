using Microsoft.Xna.Framework;

namespace YaSaog.Entities {

    public class Finish : BaseEntity {

        public Finish() : this(0, 0) { }

        public Finish(int posX, int posY) {
            X = posX;
            Y = posY;

            Size = new Vector2(32, 32);

            Collidable = true;
            CollisionType = "finish";
        }

        public override void Init() {
            
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);


        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, Color.Yellow);
        }

        public override void Delete() {
            
        }
    }
}
