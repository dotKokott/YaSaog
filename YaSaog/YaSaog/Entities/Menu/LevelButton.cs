using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Scores;

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

            var score = Score.LoadFromFile(int.Parse(Text).ToString("00") + ".oel");

            for (int i = 0; i < 3; i++) {
                var pos = new Vector2(X + (i * 18), Y + 50);
                var color = Color.Gray;

                if (score != null && i < score.StarCount) {
                    color = Color.Green;
                }

                spriteBatch.Draw(Assets.BubbleBlue, new Rectangle((int)pos.X, (int)pos.Y, 32, 32), color);
            }   
        }
    }
}
