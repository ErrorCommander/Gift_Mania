using Gameplay.Interactive;
using UnityEngine;

namespace Gameplay
{
    public class FailSendGiftAnimation : MonoBehaviour
    {
        [SerializeField] private Customer _customer;
        [SerializeField] private Animation _animation;

        private void Awake() => _customer.OnFailSendGift += PlayAnimation;

        private void OnDestroy() => _customer.OnFailSendGift -= PlayAnimation;

        private void PlayAnimation() => _animation.Play();
    }
}
