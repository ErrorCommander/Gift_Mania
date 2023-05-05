using UnityEngine;

namespace Gameplay
{
    public class ParentMovedItems : MonoBehaviour
    {
        public static Transform Parent;

        private void Awake() => Parent = transform;

        private void OnDestroy() => Parent = null;
    }
}
