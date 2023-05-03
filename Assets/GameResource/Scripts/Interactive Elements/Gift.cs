using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Gift : InteractiveMovableItem<GiftInfo>
    {
        [SerializeField] private Image _imageGift;
        
        private GiftInfo _giftInfo = new GiftInfo(new BoxInfo(ElementColor.Blue));

        public bool AddElement(BoxInfo box)
        {
            if (_giftInfo != null)
                return false;

            _giftInfo = new GiftInfo(box);
            ColorImage();

            return true;
        }

        public bool AddElement(BowInfo bow)
        {
            if (_giftInfo == null)
                return false;
            
            bool result = _giftInfo.AddElement(bow);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            return result;
        }

        public bool AddElement(OrnamentInfo ornament)
        {
            if (_giftInfo == null)
                return false;
            
            bool result = _giftInfo.AddElement(ornament);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            return result;
        }

        protected override void RealiseItem(bool isTransferred)
        {
            if (!isTransferred) 
                return;
            
            _giftInfo = null;
            ColorImage();
        }

        protected override GiftInfo GetItem()
        {
            return _giftInfo;
        }

        private void ColorImage()
        {
            if (_giftInfo == null)
            {
                _imageGift.color = Color.gray;
                return;
            }
            
            switch (_giftInfo.BoxColor)
            {
                case ElementColor.Blue:
                    _imageGift.color = Color.blue;
                    break;
                case ElementColor.Red:
                    _imageGift.color = Color.red;
                    break;
                case ElementColor.Green:
                    _imageGift.color = Color.green;
                    break;
            }
        }
    }
}