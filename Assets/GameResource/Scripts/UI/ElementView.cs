using Gameplay.ItemInfo;
using Gameplay.SO;
using UnityEngine;

namespace Gameplay
{
    public class ElementView : BaseItemViewer<ElementInfo>
    {
        [SerializeField] private ElementGiftSpriteContainer _spriteContainer;
        
        protected override Sprite GetSprite() => _spriteContainer.GetSprite(_itemInfo.ElementColor);
    }
}