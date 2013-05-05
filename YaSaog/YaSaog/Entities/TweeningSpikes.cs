using Microsoft.Xna.Framework;
using YaSaog.Tweening;
using YaSaog.Utils;

namespace YaSaog.Entities {

    public class TweeningSpikes : BaseEntity {

        private Tweener tweenX { get; set; }
        private Tweener tweenY { get; set; }
        
        public string TweenName { get; set; }
        
        public int ToX { get; set; }
        public int ToY { get; set; }
        public float Duration { get; set; }

        public TweeningSpikes() : this(0, 0) { }
        public TweeningSpikes(int posX, int posY) {
            X = posX;
            Y = posY;

            Size = new Vector2(32, 32);

            collidable = true;
            CollisionType = "spike";

            TweenName = "Linear.EaseIn";
            ToX = posX;
            ToY = posY;
        }

        public override void Init() {
            var tweenClass = TweenName.Split('.')[0];
            var tweenMethod = TweenName.Split('.')[1];

            var type = ReflectionHelper.GetTypeByName("YaSaog.Tweening." + tweenClass);
            var method = type.GetMethod(tweenMethod);

            var del = (TweeningFunction)TweeningFunction.CreateDelegate(typeof(TweeningFunction), method);

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
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, Color.Purple);
        }

        public override void Delete() {
        }
    }
}
