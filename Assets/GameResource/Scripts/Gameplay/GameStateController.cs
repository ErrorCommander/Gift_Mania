using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class GameStateController : MonoBehaviour
    {
        public event Action OnVictory = delegate {  };
        public event Action OnDefeat = delegate {  };
        public event Action<float> OnTimerChange = delegate {  };

        [SerializeField] private CustomerController _customerController;

        private Coroutine _timer;
        
        private void Start()
        {
            _customerController.OnChangeRemainingCustomersCount += RemainingCustomersCount;
            
            if (GameMode.CurrentSettings.MissionDurationMinutes <= 0)
                OnTimerChange.Invoke(float.PositiveInfinity);
            else
                _timer = StartCoroutine(Timer(GameMode.CurrentSettings.MissionDurationMinutes * 60));
        }

        private void OnDestroy() => _customerController.OnChangeRemainingCustomersCount -= RemainingCustomersCount;

        private void RemainingCustomersCount(int count)
        {
            if (count <= 0)
                Victory();
        }

        private void Victory()
        {
            Debug.Log("Victory!");
            StopTimer();
            OnVictory.Invoke();
        }

        private void Defeat()
        {
            Debug.Log("Defeat!");
            StopTimer();
            OnDefeat.Invoke();
        }

        private void StopTimer()
        {
            if (_timer != null)
                StopCoroutine(_timer);

            _timer = null;
        }

        private IEnumerator Timer(float timeSession)
        {
            float timer = timeSession;
            while (timer > 0)
            {
                yield return new WaitForSeconds(1f);
                timer--;
                OnTimerChange.Invoke(timer);
            }

            Defeat();
        }
    }
}