//Couroutine class sponsored by @ChevyRay! Thanks :)

using System.Collections.Generic;
using System.Collections;

namespace YaSaog.Utils.Coroutines {

    public class Coroutines {

        List<IEnumerator> routines = new List<IEnumerator>();

        public int Count {
            get { return routines.Count; }
        }

        public bool Running {
            get { return routines.Count > 0; }
        }

        public Coroutines() {
        }

        public void Start(IEnumerator routine) {
            routines.Add(routine);
        }

        public void StopAll() {
            routines.Clear();
        }

        public void Update() {
            for (int i = 0; i < routines.Count; i++) {
                if (routines[i].Current is IEnumerator) {
                    if (MoveNext((IEnumerator)routines[i].Current))
                        continue;
                }

                if (!routines[i].MoveNext()) {
                    routines.RemoveAt(i--);
                }
            }
        }

        bool MoveNext(IEnumerator routine) {
            if (routine.Current is IEnumerator) {
                if (MoveNext((IEnumerator)routine.Current)) {
                    return true;
                }
            }

            return routine.MoveNext();
        }
    }
}
