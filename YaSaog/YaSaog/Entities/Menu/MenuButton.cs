﻿using System;
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
                        
            Text = text;
            Size = Assets.UI.MeasureString(text);

            OnClick = onClick;

            Selected = false;

            Collidable = true;
            CollisionType = "menubutton";
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
            var font = Selected ? Assets.MenuSelected : Assets.MenuDefault;
            spriteBatch.DrawString(font, Text, Position, Color.LimeGreen);
        }

        public override void Delete() {
            
        }
    }
}
