using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Entities.Menu {

    public class MenuButton : BaseEntity {

        public bool Selected { get; private set; }

        public Action OnClick { get; set; }

        public string Text { get; private set; }

        public MenuButton(int posX, int posY, string text, Action onClick) {
            X = posX;
            Y = posY;
                                    
            Size = Assets.UI.MeasureString(text);
            CollisionType = "menubutton";

            Text = text;
            OnClick = onClick;
            Selected = false;                       
        }

        public override void Init() {            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            base.Update(gameTime);

            var mouseState = Scene.Manager.NewMouseState;
            var mouseBox = new Rectangle(mouseState.X - 5, mouseState.Y - 5, 10, 10);
            var _selected = Selected;
            Selected = this.BoundingBox.Intersects(mouseBox);

            if (!_selected && Selected) Assets.MenuHover.Play();            

            if (Selected && mouseState.LeftButton == ButtonState.Released && Scene.Manager.OldMouseState.LeftButton == ButtonState.Pressed) {
                Assets.MenuClick.Play();
                OnClick();
            }
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            var recSize = Selected ? new Point(150, 82) : new Point(100, 55);
            spriteBatch.Draw(Assets.Button, new Rectangle((int)Position.X - (recSize.X / 2) + (int)(Size.X / 2), (int)Position.Y - (recSize.Y / 2) + (int)(Size.Y / 2), recSize.X, recSize.Y), Color.White);
            spriteBatch.DrawString(Assets.MenuDefault, Text, Position, Color.DarkRed);
        }

        public override void Delete() {            
        }
    }
}
