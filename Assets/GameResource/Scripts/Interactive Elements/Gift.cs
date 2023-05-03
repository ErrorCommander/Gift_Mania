using Gameplay.Infrastructures;
using Gameplay.ItemInfo;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Gift : InteractiveMovableItem<GiftInfo>
    {
        [SerializeField] private Image _imageGift;
        [SerializeField] private GiftSpriteContainer _spriteContainer;
        [SerializeField, Range(0, 0.5f)] private float _fadeDuration = 0.2f;
        
        private GiftInfo _giftInfo;

        public bool AddElement(BoxInfo box)
        {
            if (_giftInfo != null)
                return false;

            _giftInfo = new GiftInfo(box);
            Debug.Log($"Create gift result gift {_giftInfo}");
            SetSprite();
            AppearSprite();
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

            HideSprite();
            _giftInfo = null;
        }

        protected override GiftInfo GetItem()
        {
            return _giftInfo;
        }

        private void Start() => HideSprite();

        private void HideSprite() => _imageGift.CrossFadeAlpha(0, 0, true);

        private void AppearSprite() => _imageGift.CrossFadeAlpha(1, _fadeDuration, true);

        private void SetSprite()
        {
            if (_giftInfo == null)
                return;
            
            _imageGift.sprite = _spriteContainer.GetSprite(_giftInfo);;
        }
    }
}