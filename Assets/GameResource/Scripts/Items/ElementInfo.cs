using System;

namespace Gameplay.ItemInfo
{
    public abstract class ElementInfo : BaseItemInfo
    {
        public ElementColor ElementColor => _color;
        
        private ElementColor _color;

        public ElementInfo(ElementColor color)
        {
            if (!Enum.IsDefined(typeof(ElementColor), color))
                throw new ArgumentException("Invalid color value", nameof(color));

            _color = color;
        }
    }
}