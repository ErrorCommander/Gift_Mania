using Gameplay.Infrastructures;
using Gameplay.ItemInfo;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Customer : InteractiveItemPlace<GiftInfo>
    {
        public event Action<float, float> OnChangeWaitTime = delegate {  };
        public event Action OnFailOrder = delegate {  };
        public event Action<int> OnSuccessOrder = delegate {  };

        [SerializeField] private GiftSpriteContainer _spriteContainer;
        [SerializeField] private Image _customerImage;
        [SerializeField] private Image _giftImage;
        [SerializeField] private int _reward = 20;

        private Sprite _happy;
        private Sprite _sad;
        private Coroutine _wait;
        private GiftInfo _gift;

        public override bool TryAddItem(GiftInfo item)
        {
            if (item.Equals(_gift))
            {
                Debug.Log($"{name} AddItem " + item);
                _gift = null;
                OnSuccessOrder.Invoke(_reward);
                return true;
            }

            Debug.Log($"{name} dont get item " + item);
            return false;
        }

        public void Visit(float waitTime, Sprite happy, Sprite sad)
        {
            gameObject.SetActive(true);

            _happy = happy;
            _sad = sad;
            _customerImage.sprite = _happy;
            
            StopWait();
            if (waitTime > 0) 
                _wait = StartCoroutine(Wait(waitTime));

            _gift = new GiftInfo(GameMode.GetRandomGiftCode());
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
                OnChangeWaitTime.Invoke(timer,second);
                yield return null;
            }

            _wait = null;
            OnChangeWaitTime.Invoke(0, second);
            OnFailOrder.Invoke();
        }
    }
}