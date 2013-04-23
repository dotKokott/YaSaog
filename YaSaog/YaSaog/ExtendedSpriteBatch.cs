using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace YaSaog {

    public class ExtendedSpriteBatch : SpriteBatch {

        private Texture2D textureWhite { get; set; }

        public ExtendedSpriteBatch(GraphicsDevice graphicsDevice)
            : base(graphicsDevice) {

            this.textureWhite = new Texture2D(this.GraphicsDevice, 1, 1);
            this.textureWhite.SetData(new Color[] { Color.White });
        }

        public void DrawLine(Vector2 start, Vector2 end, Color color) {
            float length = (end - start).Length();
            float rotation = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            
            this.Draw(this.textureWhite, start, null, color, rotation, Vector2.Zero, new Vector2(length, 1), SpriteEffects.None, 0);
        }

        public void DrawRectangle(Rectangle rectangle, Color color) {
            this.Draw(this.textureWhite, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);
            this.Draw(this.textureWhite, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);
            this.Draw(this.textureWhite, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);
            this.Draw(this.textureWhite, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), color);
        }

        public void FillRectangle(Rectangle rectangle, Color color) {
            this.Draw(this.textureWhite, rectangle, color);
        }
    }
}