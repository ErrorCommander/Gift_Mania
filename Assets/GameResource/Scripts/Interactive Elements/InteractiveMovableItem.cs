using Gameplay.ItemInfo;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class InteractiveMovableItem<TValue> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler where TValue : BaseItemInfo
    {
        private RectTransform _rectTransform;
        private GraphicRaycaster _raycaster;
        private Vector3 _originalPosition;
        private Transform _originalParent;
        
        protected virtual void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _raycaster = GetComponentInParent<GraphicRaycaster>();
            _originalParent = transform.parent;
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            _originalPosition = _rectTransform.position;
            transform.SetParent(ParentMovedItems.Parent);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            var raycastResults = new List<RaycastResult>();
            _raycaster.Raycast(eventData, raycastResults);

            for (int i = 0; i < raycastResults.Count; i++)
            {
                if (raycastResults[i].gameObject.TryGetComponent(out InteractiveItemPlace<TValue> itemPlace))
                {
                    RealiseItem(itemPlace.TryAddItem(GetItem()));
                    break;
                }
            }
            
            _rectTransform.position = _originalPosition;
            transform.SetParent(_originalParent);
        }

        protected abstract void RealiseItem(bool isTransferred);

        protected abstract TValue GetItem();
    }
}
