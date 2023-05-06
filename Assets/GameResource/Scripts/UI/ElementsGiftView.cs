using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay
{
    public class ElementsGiftView : MonoBehaviour, IViewer<GiftInfo>
    {
        [SerializeField] private ElementView _boxView;
        [SerializeField] private ElementView _bowView;
        [SerializeField] private ElementView _ornamentView;

        public void SetSprite(GiftInfo giftInfo)
        {
            if (giftInfo == null)
            {
                _boxView.SetSprite(null);
                _bowView.SetSprite(null);
                _ornamentView.SetSprite(null);
                return;
            }
            
            _boxView.SetSprite(giftInfo.Box);
            _bowView.SetSprite(giftInfo.Bow);
            _ornamentView.SetSprite(giftInfo.Ormanent);
        }
    }
}
