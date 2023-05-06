using Gameplay.ItemInfo;
using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.SO
{
    [CreateAssetMenu(menuName = "My SO/ElementSprites", fileName = "ElementsSpritesPresset")]
    public class ElementGiftSpriteContainer : ScriptableObject
    {
        [SerializeField] private ElementSprite[] _sprites;

        public Sprite GetSprite(ElementInfo element) 
            => element == null ? null : GetSprite(element.ElementColor);

        public Sprite GetSprite(ElementColor color) 
            => _sprites?.FirstOrDefault(s => s.Color == color).Sprite;

        [Serializable]
        private class ElementSprite
        {
            public Sprite Sprite;
            public ElementColor Color = ElementColor.Blue;
        }
    }
}