using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public struct GameSettings
    {
        [Header("Mission Settings")] 
        [Min(0)] public float MissionDurationMinutes;
        public float CustomerWaitSeconds;
        [Min(1)] public int WinningCustomerCount;
        [Range(1,5)] public int MaxCountGiftsInOrder;
        [Range(1,5)] public int GiftPlaceCount;
        [Header("Gift Settings")]
        [Header("Box")]
        public bool BlueBox;
        public bool RedBox;
        public bool GreenBox;
        [Header("Bow")]
        public bool BlueBow;
        public bool RedBow;
        public bool GreenBow;
        [Header("Ornament")]
        public bool BlueOrnament;
        public bool RedOrnament;
        public bool GreenOrnament;

        public GameSettings(float customerWaitSeconds, float missionDurationMinutes, int winningCustomerCount)
        {
            CustomerWaitSeconds = customerWaitSeconds;
            MissionDurationMinutes = missionDurationMinutes;
            WinningCustomerCount = winningCustomerCount;

            MaxCountGiftsInOrder = 2;
            GiftPlaceCount = 1;
            
            BlueBox =
            RedBox =
            GreenBox =
            BlueBow =
            RedBow =
            GreenBow =
            BlueOrnament =
            RedOrnament =
            GreenOrnament = true;
        }
    }
}
