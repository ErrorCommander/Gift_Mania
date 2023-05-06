using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gameplay
{
    public abstract class BaseItemViewer<TValue> : MonoBehaviour, IViewer<TValue> where TValue : BaseItemInfo
    {
        [SerializeField, Range(0, 0.5f)] private float _fadeDuration = 0.1f;
        [FormerlySerializedAs("_imageGift")] [SerializeField] protected Image _image;

        protected TValue _itemInfo;
        
        public void SetSprite(TValue itemInfo)
        {
            _itemInfo = itemInfo;
            
            if (itemInfo == null)
            {
                _image.CrossFadeAlpha(0, 0, true);
                return;
            }

            _image.sprite = GetSprite();
            _image.CrossFadeAlpha(1, _fadeDuration, true);
        }
        
        protected abstract Sprite GetSprite();
    }
}