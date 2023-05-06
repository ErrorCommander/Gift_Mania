using Gameplay.Extensions;
using Gameplay.Interactive;
using Gameplay.ItemInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class CustomerController : MonoBehaviour
    {
        public event Action<int> OnChangeRemainingCustomersCount = delegate {  };
        public event Action<int> OnMoneyChanged = delegate {  };
        
        [SerializeField, Min(0)] private float _minWait = 2f;
        [SerializeField, Min(1)] private float _maxWait = 5f;
        [SerializeField] private Customer[] _customers;

        private Queue<Customer> _queueCustomers = new Queue<Customer>();
        private int _money = 0;
        private int _remainingCustomersCount;
        private Coroutine _wait;

        private void Start()
        {
            _remainingCustomersCount = GameMode.CurrentSettings.WinningCustomerCount;
            
            foreach (var customer in _customers)
            {
                customer.OnEndVisit += AddQueue;
                customer.OnSuccessOrder += SuccessfulService;
                customer.gameObject.SetActive(false);
                _queueCustomers.Enqueue(customer);
            }

            SendCustomer();
            _wait = StartCoroutine(Wait());
            OnMoneyChanged.Invoke(_money);
            OnChangeRemainingCustomersCount.Invoke(_remainingCustomersCount);
        }

        private void OnDestroy()
        {
            foreach (var customer in _customers)
            {
                customer.OnEndVisit -= AddQueue;
                customer.OnSuccessOrder -= SuccessfulService;
            }
        }

        private void SuccessfulService(int value)
        {
            _money += value;
            _remainingCustomersCount--;
            
            if (_remainingCustomersCount <= 0)
            {
                _remainingCustomersCount = 0;
                if(_wait != null)
                    StopCoroutine(_wait);
            }
            
            OnMoneyChanged.Invoke(_money);
            OnChangeRemainingCustomersCount.Invoke(_remainingCustomersCount);
        }

        private void AddQueue(Customer customer) => _queueCustomers.Enqueue(customer);

        private void SendCustomer()
        {
            if (_queueCustomers.Count == 0)
                return;

            int giftCount = 1 + Random.Range(0, GameMode.CurrentSettings.MaxCountGiftsInOrder);
            int reward = -10 + 25 * giftCount;
            Queue<GiftInfo> gifts = new Queue<GiftInfo>();
            for (int i = 0; i < giftCount; i++)
            {
                gifts.Enqueue(new GiftInfo(GameMode.GetRandomGiftCode()));
            }
            
            _queueCustomers.Dequeue()
                .With(c => c.gameObject.SetActive(true))
                .Visit(GameMode.CurrentSettings.CustomerWaitSeconds, reward, gifts);
        }

        private IEnumerator Wait()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_minWait, _maxWait));
                SendCustomer();
            }
        }
    }
}
