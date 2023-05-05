using UnityEngine;

namespace Gameplay.Extensions
{
    public static class StringExtensions
    {
        public static string ToStringTimeFormat(this float timeSeconds)
        {
            if (timeSeconds == float.PositiveInfinity)
                return "∞";

            if (timeSeconds == float.NegativeInfinity)
                return "-∞";

            if (timeSeconds != timeSeconds)
                return "NaN";

            int minutes = Mathf.FloorToInt(timeSeconds / 60f);
            int seconds = Mathf.FloorToInt(timeSeconds % 60f);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}