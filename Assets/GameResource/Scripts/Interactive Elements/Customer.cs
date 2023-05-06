using Gameplay.ItemInfo;
using Gameplay.SO;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactive
{
    public class Customer : InteractiveItemPlace<GiftInfo>
    {
        private const float SAD_BORDER = 0.3f;
        public event Action<float, float> OnChangeWaitTime = delegate {  };
        public event Action OnFailOrder = delegate {  };
        public event Action OnFailSendGift = delegate {  };
        public event Action OnSuccessfulSendGift = delegate {  };
        public event Action<int> OnSuccessOrder = delegate {  };
        public event Action<Customer> OnEndVisit = delegate (Customer customer) { customer.gameObject.SetActive(false); };

        [SerializeField] private GiftView _giftView;
        [SerializeField] private ElementsGiftView _elementsGiftView;
        [SerializeField] private Image _customerImage;
        [SerializeField] private TextMeshProUGUI _queueGiftText;
        [SerializeField] private CustomerSpriteContainer _spriteContainer;
        
        private int _reward = 20;
        private Queue<GiftInfo> _giftQueue;
        private Sprite _happy;
        private Sprite _sad;
        private Coroutine _wait;
        private GiftInfo _gift;
        private bool _isHappy= true;

        public void Visit(float waitTime, int reward, GiftInfo gift)
        {
            GetSpritePresset();
            _reward = reward;

            SetHappy(true);
            
            StopWait();
            if (waitTime > 0) 
                _wait = StartCoroutine(Wait(waitTime));

            SetGift(gift);
        }

        public void Visit(float waitTime, int reward, Queue<GiftInfo> gifts)
        {
            _giftQueue = gifts;
            Visit( waitTime, reward, _giftQueue.Dequeue());
        }

        public override bool TryAddItem(GiftInfo item)
        {
            if (item == null)
                return false;

            if (item.Equals(_gift))
            {
                Debug.Log($"{name} AddItem " + item);
                _gift = null;

                if (_giftQueue == null || _giftQueue.Count == 0)
                {
                    OnSuccessOrder.Invoke(_reward);
                    OnEndVisit.Invoke(this);
                }
                else
                    SetGift(_giftQueue.Dequeue());

                OnSuccessfulSendGift.Invoke();
                return true;
            }

            Debug.Log($"{name} dont get item " + item);
            OnFailSendGift.Invoke();
            return false;
        }

        private void GetSpritePresset()
        {
            var sprites = _spriteContainer.GetSprite();
            _happy = sprites.happy;
            _sad = sprites.sad;
        }

        private void SetGift(GiftInfo gift)
        {
            _gift = gift;
            _giftView.SetSprite(gift);
            _elementsGiftView.SetSprite(gift);
            SetQueueGiftsText();
        }

        private void SetQueueGiftsText()
        {
            if (_giftQueue == null || _giftQueue.Count == 0)
                _queueGiftText.text = "";
            else
                _queueGiftText.text = "+" + _giftQueue.Count;
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