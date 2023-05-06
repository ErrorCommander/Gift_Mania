using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.SO
{
    [CreateAssetMenu(menuName = "My SO/CustomerSprites", fileName = "CustomerSpritesPresset")]
    public class CustomerSpriteContainer : ScriptableObject
    {
        [SerializeField] private CustomerSkin[] _customerSkins;

        public (Sprite happy, Sprite sad) GetSprite()
        {
            var skin = _customerSkins[Random.Range(0, _customerSkins.Length)];
            return new(skin.Happy, skin.Sad);
        }

        [Serializable]
        private class CustomerSkin
        {
            public Sprite Happy;
            public Sprite Sad;
        }
    }
}