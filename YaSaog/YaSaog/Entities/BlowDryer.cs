﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Entities {

    public class BlowDryer : BaseEntity {

        private float rotation = 0f;
        private WindEmitter windEmitter { get; set; }

        public BaseEntity Target { get; set; }

        public BlowDryer()
            : base() {
                Size = new Vector2(Assets.HairDryer.Width / 2, Assets.HairDryer.Height / 2);
                collidable = false;
        }

        public override void Init() {
            windEmitter = new WindEmitter(new Vector2(10, 10), 10, 50);
            Screen.AddEntity(windEmitter);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            var mouseState = Mouse.GetState();

            X = mouseState.X;
            Y = mouseState.Y;            

            if (Target != null) {
                var delta = Target.Position - Position;
                rotation = -(float)Math.Atan2(delta.X, delta.Y) + MathHelper.ToRadians(95);

                var windEmitterPosition = Position + new Vector2(50, -15);
                
                var vec = windEmitterPosition - Position;
                vec = Vector2.Transform(vec, Matrix.CreateRotationZ(rotation));

                windEmitter.Position = Position + vec;
                windEmitter.Rotation = rotation;
                if (mouseState.LeftButton == ButtonState.Pressed) {
                    windEmitter.Emit(rotation);
                }
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.HairDryer, BoundingBox, null, Color.White, rotation, new Vector2(Assets.HairDryer.Width / 2, Assets.HairDryer.Height / 3), SpriteEffects.None, 0);
        }

        public override void Delete() {
            Screen.RemoveEntity(windEmitter);
        }
    }
}