using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    [RequireComponent(typeof(Gift))]
    public class BowGetter : InteractiveItemPlace<BowInfo>
    {
        private Gift _gift;

        private void Awake()
        {
            _gift = GetComponent<Gift>();
        }

        public override bool TryAddItem(BowInfo item)
        {
            return _gift.AddElement(item);
        }
    }
}