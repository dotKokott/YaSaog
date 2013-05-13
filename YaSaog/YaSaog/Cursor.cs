using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog {

    public class Cursor {

        public Matrix Scale { get; set; }
        public Vector2 Position { get; set; }        

        public Cursor(Matrix scale) {
            Scale = scale;
        }

        public void Update(GameTime gameTime) {
            var pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Position = Vector2.Transform(pos, Scale);
        }

        public void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Cursor, new Rectangle((int)Position.X, (int)Position.Y, 32, 32), Color.White);
        }
    }
}
