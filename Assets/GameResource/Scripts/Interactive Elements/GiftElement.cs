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

        protected override void RealiseItem(bool isTransferred)
        {
            
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            //_fadeImage.CrossFadeAlpha(1, 0.3f, true);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            //_fadeImage.CrossFadeAlpha(0, 0.3f, true);
        }
    }
}