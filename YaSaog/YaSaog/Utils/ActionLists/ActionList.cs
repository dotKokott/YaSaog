using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace YaSaog.Utils.ActionLists {
    public class ActionList : IAction {

        private List<IAction> Actions = new List<IAction>();

        public int Count {
            get {
                return Actions.Count;
            }
        }
        
        public bool IsBlocking {
            get;
            set;
        }

        bool IAction.IsComplete {
            get {
                return Count == 0;
            }
            set {
                if (value) {
                    foreach (IAction action in Actions) {
                        action.IsComplete = true;
                    }
                } else {
                    throw new ArgumentException("ActionList.IsComplete can not be set to false. Add Actions instead.");
                }
            }
        }

        public void Insert(int position, IAction action, bool blocking) {
            action.IsBlocking = blocking;

            Actions.Insert(position, action);
        } 
        
        public void AddAction(IAction action, bool blocking) {
            Insert(Actions.Count, action, blocking);            
        }

        public void InsertAfter(IAction after, IAction action, bool blocking) {
            Insert(Actions.IndexOf(after) + 1, action, blocking);
        }

        public void Update(GameTime gameTime) {
            foreach (IAction action in Actions.ToArray<IAction>()) {
                action.Update(gameTime);

                if (action.IsComplete) Actions.Remove(action);

                if (action.IsBlocking) break;
            }            
        }
    }
}
