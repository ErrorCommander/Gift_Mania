using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    public class GiftPlace : InteractiveItemPlace<BoxInfo>
    {
        [SerializeField] private Gift _gift;
        
        public override bool TryAddItem(BoxInfo item)
        {
            return _gift.AddElement(item);
        }
    }
}