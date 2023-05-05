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
        [SerializeField] private CustomerSkin[] _customerSkins;

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
            OnMoneyChanged.Invoke(0);
            OnChangeRemainingCustomersCount.Invoke(_remainingCustomersCount);
        }

        private void SuccessfulService(int value)
        {
            _money += value;
            _remainingCustomersCount--;
            OnMoneyChanged.Invoke(value);
            OnChangeRemainingCustomersCount.Invoke(_remainingCustomersCount);
        }

        private void AddQueue(Customer customer) => _queueCustomers.Enqueue(customer);

        private void SendCustomer()
        {
            if (_queueCustomers.Count == 0)
                return;
            
            var skin = _customerSkins[Random.Range(0, _customerSkins.Length)];
            _queueCustomers.Dequeue()
                .With(c => c.gameObject.SetActive(true))
                .Visit(GameMode.CurrentSettings.CustomerWaitSeconds, 
                new GiftInfo(GameMode.GetRandomGiftCode()), skin.Happy, skin.Sad);
        }

        private IEnumerator Wait()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_minWait, _maxWait));
                SendCustomer();
            }
        }
        
        [Serializable]
        private class CustomerSkin
        {
            public Sprite Happy;
            public Sprite Sad;
        }
    }
}
