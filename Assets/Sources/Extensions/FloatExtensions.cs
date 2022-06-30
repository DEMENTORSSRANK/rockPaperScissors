using UnityEngine;

namespace Sources.Extensions
{
    public static class FloatExtensions
    {
        public static int InMilliSeconds(this float value)
        {
            return Mathf.RoundToInt(value * 1000);
        }
    }
}