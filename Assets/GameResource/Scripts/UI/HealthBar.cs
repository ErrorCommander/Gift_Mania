using Gameplay.Interactive;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Gradient _gradientColor;
        [SerializeField] private Image[] _coloringImage;
        [SerializeField] private Customer _customer;

        private void Start() => _customer.OnChangeWaitTime += ApplyValue;

        private void OnDestroy() => _customer.OnChangeWaitTime -= ApplyValue;

        private void OnEnable() => ApplyValue(1f);

        private void ApplyValue(float current, float max) => ApplyValue(current / max);

        private void ApplyValue(float partValue)
        {
            _slider.normalizedValue = partValue;
            foreach (var image in _coloringImage) 
                image.color = _gradientColor.Evaluate(partValue);
        }
    }
}