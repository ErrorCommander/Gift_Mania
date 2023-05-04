using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Button))]
    public class LoadGameSettingsButton : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ApplySettings);
        }

        private void OnDestroy() 
            => _button.onClick.RemoveListener(ApplySettings);

        private void ApplySettings() 
            => GameMode.CurrentSettings = _gameSettings;
    }
}