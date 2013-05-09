using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Entities.Menu {

    public class MenuButton : BaseEntity {

        private bool selected { get; set; }

        public Action OnClick { get; set; }
        public string Text { get; private set; }

        public MenuButton(int posX, int posY, string text, Action onClick) {
            X = posX;
            Y = posY;
                        
            Text = text;
            Size = Assets.UI.MeasureString(text);

            OnClick = onClick;

            selected = false;

            Collidable = true;
            CollisionType = "menubutton";
        }

        public override void Init() {
            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            base.Update(gameTime);

            var mouseState = Mouse.GetState();
            var mouseBox = new Rectangle(mouseState.X - 5, mouseState.Y - 5, 10, 10);

            selected = this.BoundingBox.Intersects(mouseBox);

            if (selected && mouseState.LeftButton == ButtonState.Pressed) {
                OnClick();
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            var font = selected ? Assets.MenuSelected : Assets.MenuDefault;
            spriteBatch.DrawString(font, Text, Position, Color.LimeGreen);
        }

        public override void Delete() {
            
        }
    }
}
