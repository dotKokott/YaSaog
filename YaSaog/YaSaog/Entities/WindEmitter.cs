using System;
using Microsoft.Xna.Framework;

namespace YaSaog.Entities {
    public class WindEmitter : BaseEntity {

        private Random random = new Random();

        public float Rotation { get; set; }

        public int Radius { get; set; }
        public int MinParticlesPerEmit { get; set; }
        public int MaxParticlesPerEmit { get; set; }        

        public WindEmitter(int radius, int minParticlesPerEmit, int maxParticlesPerEmit) {
                Radius = radius;            
                MinParticlesPerEmit = minParticlesPerEmit;
                MaxParticlesPerEmit = maxParticlesPerEmit;

                collidable = false;                   
        }

        public override void Init() {            
        }

        public void Emit(float rotation) {
            var count = random.Next(MinParticlesPerEmit, MaxParticlesPerEmit + 1);

            for (int i = 0; i < count; i++) {
                var posX = X - Radius + random.Next(0, (int)Radius * 2);
                var posY = Y - Radius + random.Next(0, (int)Radius * 2);

                Screen.AddEntity(new WindParticle((int)posX, (int)posY, rotation));
            }
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {            
        }

        public override void Delete() {            
        }
    }
}
