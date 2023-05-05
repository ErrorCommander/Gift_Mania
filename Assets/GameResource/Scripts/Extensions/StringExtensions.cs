using UnityEngine;

namespace Gameplay.Extensions
{
    public static class StringExtensions
    {
        public static string ToStringTimeFormat(this float timeSeconds)
        {
            if (float.IsPositiveInfinity(timeSeconds))
                return "\u221E";

            if (float.IsNegativeInfinity(timeSeconds))
                return "-\u221E";

            if (float.IsNaN(timeSeconds))
                return "NaN";

            int minutes = Mathf.FloorToInt(timeSeconds / 60f);
            int seconds = Mathf.FloorToInt(timeSeconds % 60f);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}