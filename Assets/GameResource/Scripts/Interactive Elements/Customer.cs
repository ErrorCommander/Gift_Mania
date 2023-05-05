using Gameplay.ItemInfo;
using Gameplay.SO;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Customer : InteractiveItemPlace<GiftInfo>
    {
        private const float SAD_BORDER = 0.3f;
        public event Action<float, float> OnChangeWaitTime = delegate {  };
        public event Action OnFailOrder = delegate {  };
        public event Action<int> OnSuccessOrder = delegate {  };
        public event Action<Customer> OnEndVisit = delegate (Customer customer) { customer.gameObject.SetActive(false); };

        [SerializeField] private GiftSpriteContainer _spriteContainer;
        [SerializeField] private Image _customerImage;
        [SerializeField] private Image _giftImage;
        [SerializeField] private int _reward = 20;

        private Sprite _happy;
        private Sprite _sad;
        private Coroutine _wait;
        private GiftInfo _gift;
        private bool _isHappy= true;

        public override bool TryAddItem(GiftInfo item)
        {
            if (item.Equals(_gift))
            {
                Debug.Log($"{name} AddItem " + item);
                _gift = null;
                OnSuccessOrder.Invoke(_reward);
                OnEndVisit.Invoke(this);
                return true;
            }

            Debug.Log($"{name} dont get item " + item);
            return false;
        }

        public void Visit(float waitTime, GiftInfo gift, Sprite happy, Sprite sad)
        {
            _happy = happy;
            _sad = sad;

            SetHappy(true);
            
            StopWait();
            if (waitTime > 0) 
                _wait = StartCoroutine(Wait(waitTime));

            _gift = gift;
            _giftImage.sprite = _spriteContainer.GetSprite(_gift);
        }

        private void StopWait()
        {
            if(_wait != null)
                StopCoroutine(_wait);
        }

        private IEnumerator Wait(float second)
        {
            float timer = second;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                if (_isHappy && timer / second < SAD_BORDER) 
                    SetHappy(false);
                
                OnChangeWaitTime.Invoke(timer,second);
                yield return null;
            }

            _wait = null;
            OnChangeWaitTime.Invoke(0, second);
            OnFailOrder.Invoke();
            OnEndVisit.Invoke(this);
        }

        private void SetHappy(bool isHappy)
        {
            _customerImage.sprite = isHappy ? _happy : _sad;
            _isHappy = isHappy;
        }
    }
}