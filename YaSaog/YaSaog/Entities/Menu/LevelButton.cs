using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Scores;

namespace YaSaog.Entities.Menu {

    public class LevelButton : MenuButton {

        public Score Score { get; private set; }

        public LevelButton(int posX, int posY, string text, Action onClick)
            : base(posX, posY, text, onClick) {

                Size = new Vector2(64, 64);
                Score = Score.LoadFromFile(int.Parse(Text).ToString("00") + ".oel");
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            var font = Selected ? Assets.MenuSelected : Assets.MenuDefault;
            var fontSize = font.MeasureString(Text);

            spriteBatch.DrawRectangle(BoundingBox, Color.LimeGreen);
            spriteBatch.DrawString(font, Text, new Vector2(BoundingBox.Center.X - fontSize.X / 2, BoundingBox.Center.Y - fontSize.Y / 2), Color.LimeGreen);
           
            for (int i = 0; i < 3; i++) {
                var pos = new Vector2(X + (i * 18), Y + 50);
                var color = Color.Gray;

                if (Score != null && i < Score.StarCount) {
                    color = Color.White;
                }

                spriteBatch.Draw(Assets.Star, new Rectangle((int)pos.X, (int)pos.Y, 32, 32), color);
            }   
        }
    }
}
