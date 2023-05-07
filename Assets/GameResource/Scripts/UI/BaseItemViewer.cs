using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gameplay
{
    public abstract class BaseItemViewer<TValue> : MonoBehaviour, IViewer<TValue> where TValue : BaseItemInfo
    {
        [FormerlySerializedAs("_imageGift")] [SerializeField] protected Image _image;

        protected TValue _itemInfo;
        
        public void SetSprite(TValue itemInfo)
        {
            _itemInfo = itemInfo;
            
            if (itemInfo == null)
            {
                _image.gameObject.SetActive(false);
                return;
            }

            _image.sprite = GetSprite();
            _image.gameObject.SetActive(true);
        }
        
        protected abstract Sprite GetSprite();
    }
}