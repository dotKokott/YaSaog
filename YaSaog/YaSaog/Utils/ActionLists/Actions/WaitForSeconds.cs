using System;
using Microsoft.Xna.Framework;

namespace YaSaog.Utils.ActionLists.Actions {

    public class WaitForSeconds : IAction {

        float currentTime;        
        
        public float Amount { get; set; }        

        public WaitForSeconds(float amount) {
            Amount = amount;
            currentTime = amount;
        }

        public void Update(GameTime gameTime) {
            currentTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime <= 0) {
                IsComplete = true;
            }
        }

        public bool IsBlocking {
            get {
                return true;
            }
            set {
            }
        }

        public bool IsComplete {
            get;
            set;
        }
    }
}
