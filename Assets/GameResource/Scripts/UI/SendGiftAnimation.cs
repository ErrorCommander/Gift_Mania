using Gameplay.Interactive;
using UnityEngine;

namespace Gameplay
{
    public class SendGiftAnimation : MonoBehaviour
    {
        [SerializeField] private Customer _customer;
        [SerializeField] private string _failAnimationName = "Fail";
        [SerializeField] private string _successAnimationName = "Success";
        [SerializeField] private Animation _animation;

        private void Awake()
        {
            _customer.OnFailSendGift += PlayFailAnimation;
            _customer.OnSuccessfulSendGift += PlaySuccessAnimation;
        }

        private void OnDestroy()
        {
            _customer.OnFailSendGift -= PlayFailAnimation;
            _customer.OnSuccessfulSendGift -= PlaySuccessAnimation;
        }

        private void PlayFailAnimation() => _animation.Play(_failAnimationName);
        private void PlaySuccessAnimation() => _animation.Play(_successAnimationName);
    }
}
