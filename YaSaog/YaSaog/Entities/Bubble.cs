using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Scenes;

namespace YaSaog.Entities {

    public class Bubble : BaseEntity {

        private Vector2 velocity { get; set; }
        private Vector2 friction { get; set; }

        public Bubble() : this(0, 0) {            
        }

        public Bubble(int x, int y) {           
            X = x;
            Y = y;

            Size = new Vector2(32, 32);

            Offset = new Vector2(-Size.X / 2f, -Size.Y / 2f);

            velocity = new Vector2(0f, 20f);
            friction = new Vector2(0.2f, 0.2f);

            Collidable = true;
            CollisionType = "bubble";
        }

        public override void Init() {
            var dryer = new BlowDryer();
            dryer.Target = this;

            Scene.AddEntity(dryer);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            
            foreach (var part in GetCollidingEntities("windparticle")) {
                Scene.RemoveEntity(part);
                velocity += (part as WindParticle).Velocity / 100;
            }

            float _x = Math.Max(0, Math.Abs(velocity.X) - friction.X);
            float _y = Math.Max(0, Math.Abs(velocity.Y) - friction.Y);            

            velocity = new Vector2(_x * Math.Sign(velocity.X), _y * Math.Sign(velocity.Y));

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (GetFirstCollidingEntity("spike") != null) {
                Assets.DryerDry.Stop();
                Assets.BubblePop.Play();

                var level = (this.Scene as GameScene).CurrentLevel;
                Scene.Manager.SwitchScene(new GameScene(level));
            }

            foreach (var star in GetCollidingEntities("star")) {
                (star as Star).Collect();
            }

            if (GetFirstCollidingEntity("finish") != null) {
                Assets.DryerDry.Stop();
                Assets.Finish.Play();

                var scene = (GameScene)this.Scene;
                this.Scene.Manager.AddScene(new LevelFinishScene(scene));
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, new Rectangle((int)X, (int)Y, (int)Size.X + 10, (int)Size.Y + 10), null, Color.Purple, 0, new Vector2(Assets.BubbleBlue.Width / 2, Assets.BubbleBlue.Height / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {            
        }
    }
}
