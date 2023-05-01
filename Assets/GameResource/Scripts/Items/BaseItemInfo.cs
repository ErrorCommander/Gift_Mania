using UnityEngine;

namespace Gameplay.ItemInfo
{
    public abstract class BaseItemInfo
    {
        
    }
    
    public class GiftInfo : BaseItemInfo
    {
        private BoxInfo _box;
        private BowInfo _bow;
        private OrnamentInfo _ornament;

        public GiftInfo(BoxInfo box) => _box = box;

        public bool AddElement(BowInfo bow) => AddElement(bow, ref _bow);
        
        public bool AddElement(OrnamentInfo ornament) => AddElement(ornament, ref _ornament);

        private bool AddElement<TValue>(TValue other, ref TValue myElement) where TValue : ElementInfo
        {
            if (myElement != null || other == null || other.ElementColor == _box.ElementColor)
            {
                return false;
            }
            
            myElement = other;
            return true;
        }

        public override string ToString()
        {
            return $"Box {_box.ElementColor}, Bow {(_bow != null ? _bow.ElementColor : "None")}, Ornament {(_ornament != null ? _ornament.ElementColor : "None")}";
        }
    }

    public abstract class ElementInfo : BaseItemInfo
    {
        public ElementColor ElementColor => _color;
        
        private ElementColor _color;

        public ElementInfo(ElementColor color) => _color = color;
    }

    public class BoxInfo : ElementInfo
    {
        public BoxInfo(ElementColor color) : base(color) { }
    }

    public class BowInfo : ElementInfo
    {
        public BowInfo(ElementColor color) : base(color) { }
    }

    public class OrnamentInfo : ElementInfo
    {
        public OrnamentInfo(ElementColor color) : base(color) { }
    }

    public enum ElementColor
    {
        Blue = 1,
        Red = 2,
        Green = 3
    }
}
