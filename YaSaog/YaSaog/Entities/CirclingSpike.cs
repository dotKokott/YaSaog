using Microsoft.Xna.Framework;
using YaSaog.Tweening;
using YaSaog.Utils;

namespace YaSaog.Entities {

    public class CirclingSpike : BaseEntity {

        private Tweener tween { get; set; }        
        private Vector2 radiusVector { get; set; }

        public string TweenName { get; set; }
        public float Degrees { get; set; }
        public float ToDegrees { get; set; }
        public float Radius { get; set; }
        public float Duration { get; set; }
        public int Modifier { get; set; }
        public bool ReverseOnFinish { get; set; }

        public Vector2 Center { get; set; }

        public CirclingSpike() : this(0, 0) { }
        public CirclingSpike(int posX, int posY) {
            X = posX;
            Y = posY;            

            Size = new Vector2(32, 32);

            Collidable = true;
            CollisionType = "spike";

            TweenName = "Linear.EaseIn";
            ToDegrees = 360f;
            Duration = 3f;
            Modifier = 1;
            ReverseOnFinish = false;
        }

        public override void Init() {
            Center = new Vector2(X, Y);
            radiusVector = new Vector2(Radius, Radius);

            var tweenClass = TweenName.Split('.')[0];
            var tweenMethod = TweenName.Split('.')[1];

            var type = ReflectionHelper.GetTypeByName("YaSaog.Tweening." + tweenClass);
            var method = type.GetMethod(tweenMethod);

            var del = (TweeningFunction)TweeningFunction.CreateDelegate(typeof(TweeningFunction), method);

            tween = new Tweener(Degrees, ToDegrees, Duration, del);
            
            if (ReverseOnFinish) {
                tween.Ended += delegate() { tween.Reverse(); };            
            } else {
                tween.Ended += delegate() { tween.Reset(); };            
            }            
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);                        

            tween.Update(gameTime);
            Degrees = tween.Position * Modifier;

            var _pos = Center + radiusVector;
            Position = Vector2.Transform(_pos - Center, Matrix.CreateRotationZ(MathHelper.ToRadians(Degrees))) + Center;            
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Spikes, BoundingBox, Color.White);
        }

        public override void Delete() {
        }
    }
}
