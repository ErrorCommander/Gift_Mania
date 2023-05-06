using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    public class Gift : InteractiveMovableItem<GiftInfo>
    {
        [SerializeField] private GiftView _giftView;
        
        private GiftInfo _giftInfo;

        public bool AddElement(BoxInfo box)
        {
            if (_giftInfo != null)
                return false;

            _giftInfo = new GiftInfo(box);
            Debug.Log($"Create gift result gift {_giftInfo}");
            SetSprite();
            return true;
        }

        public bool AddElement(BowInfo bow)
        {
            if (_giftInfo == null)
                return false;
            
            bool result = _giftInfo.AddElement(bow);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            if (result)
                SetSprite();
            return result;
        }

        public bool AddElement(OrnamentInfo ornament)
        {
            if (_giftInfo == null)
                return false;
            
            bool result = _giftInfo.AddElement(ornament);
            Debug.Log($"Success {result} result gift {_giftInfo}");
            if (result)
                SetSprite();
            return result;
        }

        protected override void RealiseItem(bool isTransferred)
        {
            if (!isTransferred) 
                return;

            _giftInfo = null;
            SetSprite();
        }

        protected override GiftInfo GetItem()
        {
            return _giftInfo;
        }

        private void Start() => SetSprite();

        private void SetSprite()
        {
            _giftView.SetSprite(_giftInfo);
        }
    }
}