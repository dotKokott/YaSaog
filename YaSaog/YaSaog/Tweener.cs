using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

//ORIGINAL CODE FROM http://xnatweener.codeplex.com/

namespace ClownSchool.Tweening
{
    public delegate float TweeningFunction(float timeElapsed, float start, float change, float duration);

    public class Tweener
    {
        public Tweener(float from, float to, float duration, TweeningFunction tweeningFunction)
        {
            From = from;
            Position = from;
            Change = to - from;
            Function = tweeningFunction;
            Duration = duration;
            Elapsed = 0.0f;
            Running = true;
        }

        public Tweener(float from, float to, TimeSpan duration, TweeningFunction tweeningFunction)
            : this(from, to, (float)duration.TotalSeconds, tweeningFunction)
        {
        }

        public float Position { get; set; }

        protected float From { get; set; }

        protected float Change { get; set; }

        protected float Duration { get; set; }

        protected float Elapsed { get; set; }        
        
        public bool Running { get; protected set; }

        protected TweeningFunction Function { get; private set; }

        public delegate void EndHandler();
        public event EndHandler Ended;

        public void Update(GameTime gameTime)
        {
            if (!Running || (Elapsed == Duration))
            {
                return;
            }
            Position = Function(Elapsed, From, Change, Duration);
            Elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Elapsed >= Duration)
            {
                Elapsed = Duration;
                Position = From + Change;
                OnEnd();
            }
        }

        protected void OnEnd()
        {
            if (Ended != null)
            {
                Ended();
            }
        }

        public void Start()
        {
            Running = true;
        }

        public void Stop()
        {
            Running = false;
        }

        public void Reset()
        {
            Elapsed = 0.0f;
            From = Position;
        }

        public void Reset(float to)
        {
            Change = to - Position;
            Reset();
        }

        public void Reverse()
        {
            Elapsed = 0.0f;
            Change = -Change + (From + Change - Position);
            From = Position;
        }
    }
}
