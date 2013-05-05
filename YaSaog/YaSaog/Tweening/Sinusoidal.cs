using System;

//ORIGINAL CODE FROM http://xnatweener.codeplex.com/

namespace YaSaog.Tweening
{
    public static class Sinusoidal
    {
        public static float EaseIn(float elapsed, float from, float change, float duration)
        {
            return -change * (float)Math.Cos(elapsed / duration * (Math.PI / 2)) + change + from;
        }
        public static float EaseOut(float elapsed, float from, float change, float duration)
        {
            return change * (float)Math.Sin(elapsed / duration * (Math.PI / 2)) + from;
        }
        public static float EaseInOut(float elapsed, float from, float change, float duration)
        {
            return -change / 2 * ((float)Math.Cos(Math.PI * elapsed / duration) - 1) + from;
        }
    }
}
