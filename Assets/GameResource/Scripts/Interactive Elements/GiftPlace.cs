using Gameplay.ItemInfo;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class GiftPlace : InteractiveItemPlace<BoxInfo>
    {
        [SerializeField, Range(0,4)] private int _indexPlace;
        [SerializeField] private Gift _gift;
        [SerializeField] private Image _imageDesk;
        [SerializeField] private Sprite _activeSprite;
        [SerializeField] private Sprite _disableSprite;

        private void Start()
        {
            SetActivePlace(_indexPlace < GameMode.CurrentSettings.GiftPlaceCount);
        }

        private void SetActivePlace(bool state)
        {
            _gift.gameObject.SetActive(state);
            _imageDesk.sprite = state ? _activeSprite : _disableSprite;
            _imageDesk.raycastTarget = state;
        }

        public override bool TryAddItem(BoxInfo item)
        {
            return _gift.AddElement(item);
        }
    }
}