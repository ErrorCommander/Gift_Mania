using Gameplay.ItemInfo;
using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Interactive
{
    public class Customer : InteractiveItemPlace<GiftInfo>
    {
        public event Action<float, float> OnChangeWaitTime = delegate {  };


        public override bool TryAddItem(GiftInfo item)
        {
            Debug.Log($"{name} AddItem " + item);
            return true;
        }

        private void OnEnable()
        {
            StartCoroutine(Wait(30));
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
            
            OnChangeWaitTime.Invoke(0, second);
        }
    }
}