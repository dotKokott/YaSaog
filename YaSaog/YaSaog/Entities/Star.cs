using Microsoft.Xna.Framework;
using YaSaog.Tweening;
using YaSaog.Utils.ActionLists.Actions;

namespace YaSaog.Entities {

    public class Star : BaseEntity {

        public Star() : this(0, 0) { }

        public Star(int posX, int posY) {
            X = posX;
            Y = posY;
    
            Size = new Vector2(45, 45);        
            CollisionType = "star";      
        }

        public override void Init() {			
        }

        public void Collect() {
            Assets.StarCollect.Play();
            Collidable = false;
            Actions.AddAction(new TweenPositionTo(this, new Vector2(30, 10), 0.5f, Linear.EaseIn), true);
            Actions.AddAction(new CallFunction(() => { Scene.RemoveEntity(this); }), true);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Star, BoundingBox, Color.White);
        }

        public override void Delete() {			
        }
    }
}