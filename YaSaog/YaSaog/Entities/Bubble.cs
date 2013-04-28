using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Entities {

    public class Bubble : BaseEntity {

        private Vector2 velocity { get; set; }
        private Vector2 friction { get; set; }

        public Bubble(int x, int y) : base() {           
            X = x;
            Y = y;

            Size = new Vector2(60, 60);

            Offset = new Vector2(-Size.X / 2,  -Size.Y / 2);

            velocity = new Vector2(0f, 50f);
            friction = new Vector2(0.2f, 0.2f);

            collidable = true;
            CollisionType = "bubble";
        }

        public override void Init() {        
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) velocity += new Vector2(2f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) velocity += new Vector2(-2f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) velocity += new Vector2(0, -2f);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) velocity += new Vector2(0, 2f);

            foreach (var part in GetCollidingEntities("windparticle")) {
                Screen.RemoveEntity(part);
                velocity += (part as WindParticle).Velocity / 100;
            }

            float _x = Math.Max(0, Math.Abs(velocity.X) - friction.X);
            float _y = Math.Max(0, Math.Abs(velocity.Y) - friction.Y);            

            velocity = new Vector2(_x * Math.Sign(velocity.X), _y * Math.Sign(velocity.Y));

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;           
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, new Rectangle((int)X, (int)Y, (int)Size.X + 20, (int)Size.Y + 20), null, Color.White, 0, new Vector2(Assets.BubbleBlue.Width / 2, Assets.BubbleBlue.Height / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {            
        }
    }
}
