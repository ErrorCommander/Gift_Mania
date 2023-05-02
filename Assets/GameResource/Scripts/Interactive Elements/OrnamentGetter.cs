using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    [RequireComponent(typeof(Gift))]
    public class OrnamentGetter : InteractiveItemPlace<OrnamentInfo>
    {
        private Gift _gift;

        private void Awake()
        {
            _gift = GetComponent<Gift>();
        }

        public override bool TryAddItem(OrnamentInfo item)
        {
            return _gift.AddElement(item);
        }
    }
}