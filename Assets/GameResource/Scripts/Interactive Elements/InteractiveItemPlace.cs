using Gameplay.ItemInfo;
using UnityEngine;

namespace Gameplay.Interactive
{
    public abstract class InteractiveItemPlace<TValue> : MonoBehaviour where TValue : BaseItemInfo
    {
        public abstract bool TryAddItem(TValue item);
    }
}