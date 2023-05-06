using Gameplay.ItemInfo;
using Gameplay.SO;
using UnityEngine;

namespace Gameplay
{
    public class GiftView : BaseItemViewer<GiftInfo>
    {
        [SerializeField] private GiftSpriteContainer _spriteContainer;
        
        protected override Sprite GetSprite() => _spriteContainer.GetSprite(_itemInfo);
    }
}