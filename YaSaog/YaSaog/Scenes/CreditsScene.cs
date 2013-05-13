using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using YaSaog.Entities.Menu;

namespace YaSaog.Scenes {

    public class CreditsScene : BaseScene {

        public override void Init() {
            base.Init();

            var back = new MenuButton(30, MainGame.Height - 80, "Back", () => { Manager.SwitchScene(new MenuScene()); });
            AddEntity(back);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Manager.NewKeyboardState.IsKeyDown(Keys.Escape)) Manager.SwitchScene(new MenuScene());
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.MenuBackground, new Rectangle(0, 0, MainGame.Width, MainGame.Height), Color.White);
            
            base.Draw(spriteBatch);

            var pos = new Vector2((MainGame.Width / 2) - 100, (MainGame.Height / 2) - 200);

            spriteBatch.DrawString(Assets.UI, "Christian Kokott", pos, Color.Red);
            spriteBatch.DrawString(Assets.UI, "Art Assets: Damla", new Vector2(pos.X, pos.Y + 75), Color.Yellow);
            spriteBatch.DrawString(Assets.UI, "Sound & SFX: freesounds.org & opengameart.org (see README)", new Vector2(pos.X - 260, pos.Y + 120), Color.Yellow);
            spriteBatch.DrawString(Assets.UI, "Easing functions: xnatweener.codeplex.com", new Vector2(pos.X - 160, pos.Y + 165), Color.Yellow);
        }
    }
}
