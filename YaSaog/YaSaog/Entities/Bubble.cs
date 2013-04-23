﻿using System;
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

            Size = new Vector2(75, 75);

            velocity = new Vector2(0f, 50f);
            friction = new Vector2(0.2f, 0.2f);
        }

        public override void Init() {        
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) velocity += new Vector2(2f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) velocity += new Vector2(-2f, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) velocity += new Vector2(0, -2f);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) velocity += new Vector2(0, 2f);

            float _x = Math.Max(0, Math.Abs(velocity.X - friction.X));
            float _y = Math.Max(0, Math.Abs(velocity.Y - friction.Y));            

            velocity = new Vector2(_x * Math.Sign(velocity.X), _y * Math.Sign(velocity.Y));

            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.BubbleBlue, BoundingBox, null, Color.White, 0, new Vector2(Assets.BubbleBlue.Width / 2, Assets.BubbleBlue.Height / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {            
        }
    }
}
