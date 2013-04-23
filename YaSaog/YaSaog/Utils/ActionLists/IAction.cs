using Microsoft.Xna.Framework;

namespace YaSaog.Utils.ActionLists {

    public interface IAction {
        bool IsBlocking { get; set; }
        bool IsComplete { get; set; }

        void Update(GameTime gameTime);
    }
}
