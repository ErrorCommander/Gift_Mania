using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public abstract class GiftElement<TValue> : InteractiveMovableItem<TValue> where TValue : ElementInfo
    {
        [SerializeField] protected ElementColor _elementColor = ElementColor.Blue;
        [SerializeField] protected Image _fadeImage;
        [SerializeField, Range(0, 0.5f)] private float _fadeDuration = 0.2f;
        protected override void RealiseItem(bool isTransferred)
        {
            
        }

        protected override void Awake()
        {
            base.Awake();
            _fadeImage.CrossFadeAlpha(0, 0f, true);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            _fadeImage.CrossFadeAlpha(1, _fadeDuration, true);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            _fadeImage.CrossFadeAlpha(0, 0f, true);
        }
    }
}