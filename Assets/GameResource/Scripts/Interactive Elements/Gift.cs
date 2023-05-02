using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Gift : InteractiveMovableItem<GiftInfo>
    {
        [SerializeField] private Image _imageGift;
        
        private GiftInfo _giftInfo = new GiftInfo(new BoxInfo(ElementColor.Blue));

        public bool AddElement(BowInfo bow)
        {
            bool result = _giftInfo.AddElement(bow);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            return result;
        }
        
        public bool AddElement(OrnamentInfo ornament)
        {
            bool result = _giftInfo.AddElement(ornament);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            return result;
        }
        
        protected override void RealiseItem(bool isTransferred)
        {
            if (isTransferred)
            {
                _giftInfo = new GiftInfo(new BoxInfo((ElementColor)Random.Range(1,4)));
                switch (_giftInfo.BoxColor)
                {
                    case ElementColor.Blue :
                        _imageGift.color = Color.blue;
                        break;
                    case ElementColor.Red :
                        _imageGift.color = Color.red;
                        break;
                    case ElementColor.Green :
                        _imageGift.color = Color.green;
                        break;
                }
            }
        }

        protected override GiftInfo GetItem()
        {
            return _giftInfo;
        }
    }
}