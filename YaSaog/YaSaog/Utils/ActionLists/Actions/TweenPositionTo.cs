using Microsoft.Xna.Framework;
using YaSaog.Entities;
using YaSaog.Tweening;

namespace YaSaog.Utils.ActionLists.Actions {

    class TweenPositionTo : IAction {

        private BaseEntity entity { get; set; }
        private Vector2 to { get; set; }
        private float duration { get; set; }
        private TweeningFunction tween { get; set; }

        private Tweener tweenerX { get; set; }
        private Tweener tweenerY { get; set; }
        private bool tweenerXFinished { get; set; }
        private bool tweenerYFinished { get; set; }
        
        public bool IsBlocking { get; set; }

        public bool IsComplete {
            get {
                return tweenerXFinished && tweenerYFinished;
            }
            set {
                tweenerXFinished = tweenerYFinished = true;
            }
        }

        public TweenPositionTo(BaseEntity entity, Vector2 to, float duration, TweeningFunction tween) {
            this.entity = entity;
            this.to = to;
            this.duration = duration;
            this.tween = tween;            
        }

        void initTweeners() {
            tweenerX = new Tweener(entity.X, to.X, duration, tween);
            tweenerY = new Tweener(entity.Y, to.Y, duration, tween);

            tweenerX.Ended += delegate() { tweenerXFinished = true; };
            tweenerY.Ended += delegate() { tweenerYFinished = true; };
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            if (tweenerX == null || tweenerY == null) {
                initTweeners();
            }

            tweenerX.Update(gameTime);
            tweenerY.Update(gameTime);

            entity.X = (int)tweenerX.Position;
            entity.Y = (int)tweenerY.Position;
        }
    }
}
