using Gameplay.Extensions;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ObserverGameState : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private TextMeshProUGUI _customerCountText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private CustomerController _customerController;
        [SerializeField] private GameState _gameState;

        private void Start()
        {
            _customerController.OnChangeRemainingCustomersCount += CustomerChange;
            _customerController.OnMoneyChanged += MoneyChange;
            _gameState.OnTimerChange += TimeChange;
        }

        private void OnDestroy()
        {
            _customerController.OnChangeRemainingCustomersCount -= CustomerChange;
            _customerController.OnMoneyChanged -= MoneyChange;
            _gameState.OnTimerChange -= TimeChange;
        }

        private void MoneyChange(int value) => _moneyText.text = value.ToString();

        private void CustomerChange(int count) => _customerCountText.text = count.ToString();

        private void TimeChange(float timer) => _timerText.text = timer.ToStringTimeFormat();
    }
}