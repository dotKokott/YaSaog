using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YaSaog.Entities {

    public class Bubble : BaseEntity {

        private Vector2 velocity { get; set; }

        public Bubble(int x, int y) : base() {           
            X = x;
            Y = y;

            Size = new Vector2(75, 75);

            velocity = new Vector2(0, 20f);
        }

        public override void Init() {        
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, null, Color.White, 0, new Vector2(Assets.BubbleBlue.Width / 2, Assets.BubbleBlue.Height / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {
            throw new NotImplementedException();
        }
    }
}
