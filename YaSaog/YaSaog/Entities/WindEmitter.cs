using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YaSaog.Entities {
    public class WindEmitter : BaseEntity {

        private Random random = new Random();

        public float Rotation { get; set; }
        
        public int MinParticlesPerEmit { get; set; }
        public int MaxParticlesPerEmit { get; set; }        

        public WindEmitter(Vector2 size, int minParticlesPerEmit, int maxParticlesPerEmit)
            : base() {

                MinParticlesPerEmit = minParticlesPerEmit;
                MaxParticlesPerEmit = maxParticlesPerEmit;

                collidable = false;
                Size = size;                
        }

        public override void Init() {
            
        }

        public void Emit(float rotation) {
            var count = random.Next(MinParticlesPerEmit, MaxParticlesPerEmit + 1);
            count = 3;
            for (int i = 0; i < count; i++) {
                var posX = X + (Size.X - random.Next(0, (int)(X + Size.X - X)));
                var posY = Y + (Size.Y - random.Next(0, (int)(Y + Size.Y - Y)));

                Screen.AddEntity(new WindParticle((int)posX, (int)posY, rotation));
            }
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteBatch.TextureWhite, BoundingBox, null, Color.Red, Rotation, new Vector2(spriteBatch.TextureWhite.Width / 2, spriteBatch.TextureWhite.Width / 2), SpriteEffects.None, 0);
        }

        public override void Delete() {
            
        }
    }
}
