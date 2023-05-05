using UnityEngine;

namespace Gameplay.ItemInfo
{
    public class GiftInfo : BaseItemInfo
    {
        private BoxInfo _box;
        private BowInfo _bow;
        private OrnamentInfo _ornament;

        public GiftInfo(BoxInfo box) => _box = box;

        public GiftInfo(int code)
        {
            _box = new BoxInfo((ElementColor)(code / 100));
            _bow = new BowInfo((ElementColor)((code / 10) % 10));
            _ornament = new OrnamentInfo((ElementColor)(code % 10));
        }

        public bool AddElement(BowInfo bow) => AddElement(bow, ref _bow);
        
        public bool AddElement(OrnamentInfo ornament) => AddElement(ornament, ref _ornament);

        public int GetGiftCode() => GetCode(10);

        public override string ToString()
        {
            return $"Gift {GetGiftCode()} : Box {_box.ElementColor}, Bow {(_bow != null ? _bow.ElementColor : "None")}, Ornament {(_ornament != null ? _ornament.ElementColor : "None")}";
        }

        public override bool Equals(object other)
        {
            var otherGift = other as GiftInfo;

            if (otherGift == null)
                return false;

            return this.GetGiftCode().Equals(otherGift.GetGiftCode());
        }

        public override int GetHashCode() => GetCode(3527);

        private bool AddElement<TValue>(TValue other, ref TValue myElement) where TValue : ElementInfo
        {
            if (myElement != null || other == null || other.ElementColor == _box.ElementColor)
            {
                return false;
            }
            
            myElement = other;
            return true;
        }

        private int GetCode(int seed) =>  (_box == null ? 0 : (int)_box.ElementColor * seed * seed)
                                          + (_bow == null ? 0 : (int)_bow.ElementColor * seed)
                                          + (_ornament == null ? 0 : (int)_ornament.ElementColor);
    }
}