using Microsoft.Xna.Framework;
using YaSaog.Tweening;
using YaSaog.Utils;

namespace YaSaog.Entities {

    public class TweeningSpike : BaseEntity {

        private Tweener tweenX { get; set; }
        private Tweener tweenY { get; set; }
        
        public string TweenName { get; set; }
        
        public int ToX { get; set; }
        public int ToY { get; set; }
        public float Duration { get; set; }

        public TweeningSpike() : this(0, 0) { }
        public TweeningSpike(int posX, int posY) {
            X = posX;
            Y = posY;

            Size = new Vector2(32, 32);

            Collidable = true;
            CollisionType = "spike";

            TweenName = "Linear.EaseIn";
            ToX = posX;
            ToY = posY;
        }

        public override void Init() {
            var del = ReflectionHelper.GetTweenDelegateByName(TweenName);

            tweenX = new Tweener(X, ToX, Duration, del);
            tweenX.Ended += delegate() { tweenX.Reverse(); };
            
            tweenY = new Tweener(Y, ToY, Duration, del);
            tweenY.Ended += delegate() { tweenY.Reverse(); };
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            tweenX.Update(gameTime);
            X = tweenX.Position;

            tweenY.Update(gameTime);
            Y = tweenY.Position;
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Spikes, BoundingBox, Color.White);
        }

        public override void Delete() {
        }
    }
}
