using Gameplay.ItemInfo;
using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.Infrastructures
{
    [CreateAssetMenu(menuName = "My SO/GiftSprites", fileName = "GiftSpritesPresset")]
    public class GiftSpriteContainer : ScriptableObject
    {
        [SerializeField] private GiftSprite[] _giftSprites;

        /// <summary>
        /// Get the appropriate sprite for the gift.
        /// If no matches are found the result will be null.
        /// </summary>
        /// <param name="gift"></param>
        /// <returns>Gift Sprite, result may be null.</returns>
        public Sprite GetSprite(GiftInfo gift) => GetSprite(gift?.GetGiftCode() ?? 0);
        
        /// <summary>
        /// Get the appropriate sprite for the gift.
        /// If no matches are found the result will be null.
        /// </summary>
        /// <param name="giftCode">Gift configuration code.</param>
        /// <returns>Gift Sprite, result may be null.</returns>
        public Sprite GetSprite(int giftCode)
        {
            return _giftSprites?.FirstOrDefault(gs => gs.Code == giftCode)?.Sprite;
        }
        
        [Serializable]
        private class GiftSprite
        {
            public Sprite Sprite;
            public int Code;
        }
    }
}
