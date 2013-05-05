using System;
using System.Collections.Generic;
using System.Text;

//ORIGINAL CODE FROM http://xnatweener.codeplex.com/

namespace ClownSchool.Tweening
{
    public static class Linear
    {
        public static float EaseNone(float elapsed, float from, float change, float duration)
        {
            return change * elapsed / duration + from;
        }

        public static float EaseIn(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        public static float EaseOut(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        public static float EaseInOut(float t, float b, float c, float d)
        {
            return c * t / d + b;
	    }
    }
}
