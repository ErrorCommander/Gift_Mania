using UnityEngine;

namespace Gameplay
{
    public class LoadGameButton : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        
        [ContextMenu("TestCombining")]
        private void ApplySettings()
        {
            GameMode.CurrentSettings = _gameSettings;
        }
    }
}