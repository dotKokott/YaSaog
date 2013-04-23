using System;
using Microsoft.Xna.Framework;

namespace YaSaog.Utils.ActionLists.Actions {

    public class CallFunction : IAction {

        public Action Function { get; set;}

        public bool IsBlocking {
            get;
            set;
        }

        public bool IsComplete {
            get;
            set;
        }

        public CallFunction(Action function) {
            Function = function;
        }

        public void Update(GameTime gameTime) {
            Function();

            IsComplete = true;
        }
    }
}
