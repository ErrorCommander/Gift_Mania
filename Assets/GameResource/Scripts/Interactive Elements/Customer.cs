using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    public class Customer : InteractiveItemPlace<GiftInfo>
    {
        public override bool TryAddItem(GiftInfo item)
        {
            Debug.Log($"{name} AddItem " + item);
            return true;
        }
    }
}