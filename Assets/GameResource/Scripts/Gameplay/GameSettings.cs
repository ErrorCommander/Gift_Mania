using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public struct GameSettings
    {
        public float CustomerWaitSec;
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
    }
}
