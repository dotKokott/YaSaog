using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Scenes {
    public class CreditsScene : BaseScene {

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Manager.NewKeyboardState.IsKeyDown(Keys.Escape)) Manager.SwitchScene(new MenuScene());
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            base.Draw(spriteBatch);

            var pos = new Vector2((MainGame.Width / 2) - 100, (MainGame.Height / 2) - 200);

            spriteBatch.DrawString(Assets.UI, "Christian Kokott", pos, Color.Red);
            spriteBatch.DrawString(Assets.UI, "Art Assets: Damla Yasar", new Vector2(pos.X - 40, pos.Y + 75), Color.Yellow);
            spriteBatch.DrawString(Assets.UI, "Sound & SFX: freesounds.org & opengameart.org (see README)", new Vector2(pos.X - 260, pos.Y + 120), Color.Yellow);
        }
    }
}
