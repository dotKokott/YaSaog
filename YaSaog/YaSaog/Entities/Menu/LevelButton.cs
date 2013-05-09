using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace YaSaog.Entities.Menu {

    public class LevelButton : MenuButton {

        public LevelButton(int posX, int posY, string text, Action onClick)
            : base(posX, posY, text, onClick) {

                Size = new Vector2(64, 64);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            var font = Selected ? Assets.MenuSelected : Assets.MenuDefault;
            var fontSize = font.MeasureString(Text);

            spriteBatch.DrawRectangle(BoundingBox, Color.LimeGreen);
            spriteBatch.DrawString(font, Text, new Vector2(BoundingBox.Center.X - fontSize.X / 2, BoundingBox.Center.Y - fontSize.Y / 2), Color.LimeGreen);
        }
    }
}
