using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YaSaog.Scenes {

    public class PauseScene : BaseScene {

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            var oldState = Manager.OldKeyboardState;
            var state = Manager.NewKeyboardState;

            if (!oldState.IsKeyDown(Keys.P) && state.IsKeyDown(Keys.P)) Manager.RemoveScene(this);
        }

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteBatch.TextureWhite, new Rectangle(0, 0, MainGame.Width, MainGame.Height), Color.Black * 0.7f);            

            base.Draw(spriteBatch);
        }
    }
}
