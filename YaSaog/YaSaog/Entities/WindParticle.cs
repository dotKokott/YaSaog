using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
namespace YaSaog.Entities {
    public class WindParticle : BaseEntity {

        public float Speed { get; set; }
        public float Rotation { get; set; }
        public float Friction { get; set; }
        public Vector2 InitialVelocity { get; private set; }
        public Vector2 Velocity { get; private set; } 
      

        public WindParticle(int x, int y, float rotation)
            : base() {

                X = x;
                Y = y;
                Rotation = rotation;
                Friction = 10f;
                Speed = 500f;

                Size = new Vector2(10, 3);

                collidable = true;
                CollisionType = "windparticle";
        }

        public override void Init() {            
            InitialVelocity = new Vector2(Speed * (float)Math.Cos(Rotation), Speed * (float)Math.Sin(Rotation));
            Velocity = InitialVelocity;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);                        

            float _x = Math.Max(0, Math.Abs(Velocity.X) - Math.Abs(Friction * (float)Math.Cos(Rotation)));
            float _y = Math.Max(0, Math.Abs(Velocity.Y) - Math.Abs(Friction * (float)Math.Sin(Rotation)));

            Velocity = new Vector2(_x * Math.Sign(Velocity.X), _y * Math.Sign(Velocity.Y));

            X += Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;            

            if (Velocity.X == 0 && Velocity.Y == 0) {
                Screen.RemoveEntity(this);
            }

            //Rotation = new Vector2(_x * Math.Sign(Rotation.X), _y * Math.Sign(Rotation.Y));

            //rotation = (float)Math.Atan2(Rotation.X, Rotation.Y) + MathHelper.ToRadians(90);

            //X += Rotation.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Y += Rotation.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (Rotation.X == 0 && Rotation.Y == 0) {
            //    Screen.RemoveEntity(this);
            //}
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, null, Color.White * (1 / InitialVelocity.Length()) * Velocity.Length(), Rotation, new Vector2(Assets.BubbleBlue.Width / 2, Assets.BubbleBlue.Height / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {
            
        }
    }
}
