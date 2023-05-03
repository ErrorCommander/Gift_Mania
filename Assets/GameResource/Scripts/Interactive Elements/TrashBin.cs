using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    public class TrashBin : InteractiveItemPlace<GiftInfo>
    {
        public override bool TryAddItem(GiftInfo item)
        {
            Debug.Log($"{name} move to bin " + item);
            return true;
        }
    }
}