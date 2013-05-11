using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Entities {

    public class BlowDryer : BaseEntity {

        public BaseEntity Target { get; set; }

        private float rotation = 0f;
        private WindEmitter windEmitter { get; set; }

        public BlowDryer() {
            Size = new Vector2(Assets.HairDryer.Width / 2, Assets.HairDryer.Height / 2);
            Collidable = false;

            ZDepth = 1000;
        }

        public override void Init() {
            windEmitter = new WindEmitter(10, 1, 3);
            Scene.AddEntity(windEmitter);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            var _mouseState = Scene.Manager.OldMouseState;
            var mouseState = Scene.Manager.NewMouseState;

            if (_mouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed) {
                Assets.DryerOn.Play();
            }

            if (_mouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released) {
                Assets.DryerOn.Stop();
                Assets.DryerDry.Stop();
                Assets.DryerOff.Play();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && Assets.DryerOn.State == SoundState.Stopped && Assets.DryerDry.State != SoundState.Playing) {
                Assets.DryerDry.Play();
            }                        

            X = mouseState.X;
            Y = mouseState.Y;            

            if (Target != null) {
                var delta = Target.Position - Position;
                rotation = -(float)Math.Atan2(delta.X, delta.Y) + MathHelper.ToRadians(95);

                var windEmitterPosition = Position + new Vector2(70, -10);
                
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
            Scene.RemoveEntity(windEmitter);
        }
    }
}
