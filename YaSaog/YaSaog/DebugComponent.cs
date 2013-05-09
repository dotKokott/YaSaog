using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YaSaog {

    public class DebugComponent {

        private MainGame Game;

        private float fps = 0;
        private float updateInterval = 1.0f;        
        private float timeSinceLastDraw = 0.0f;                
        private float frameCount = 0;

        public bool Enabled { get; set; }

        public DebugComponent(MainGame game) {
            Game = game;
        }

        public void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.F12))
                Enabled = !Enabled;
        }

        public void Draw(ExtendedSpriteBatch spriteBatch, GameTime gameTime) {
            if (!Enabled)
                return;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCount++;
            timeSinceLastDraw += elapsed;
            if (timeSinceLastDraw > updateInterval) {
                fps = frameCount / timeSinceLastDraw;

                Game.Window.Title = "FPS: " + fps.ToString();

                frameCount = 0;
                timeSinceLastDraw -= updateInterval;
            }
            
            spriteBatch.DrawString(Assets.SmallDebug, "FPS: " + fps.ToString(), new Vector2(MainGame.Width - 150, 0), Color.Lime);
            spriteBatch.DrawString(Assets.SmallDebug, "Entities: " + Game.SceneManager.TopScene.Entities.Count.ToString(), new Vector2(MainGame.Width - 150, 10), Color.Lime);

            foreach (var ent in Game.SceneManager.TopScene.Entities.Where(ent => ent.Collidable)) {
                spriteBatch.DrawRectangle(ent.BoundingBox, Color.Red);
            }
        }
    }
}
