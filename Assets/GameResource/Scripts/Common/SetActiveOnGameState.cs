using UnityEngine;

namespace Gameplay.Common
{
    public class SetActiveOnGameState : MonoBehaviour
    {
        [SerializeField] private GameStateAction _onGameState;
        [SerializeField] private bool _setActive;
        [SerializeField] private Transform[] _objects;
        [SerializeField] private GameStateController _gameState;

        private void Start()
        {
            switch (_onGameState)
            {
                case GameStateAction.Victory:
                    _gameState.OnVictory += SetActiveObjects;
                    break;
                case GameStateAction.Defeat:
                    _gameState.OnDefeat += SetActiveObjects;
                    break;
            }
        }
        
        private void OnDestroy()
        {
            switch (_onGameState)
            {
                case GameStateAction.Victory:
                    _gameState.OnVictory -= SetActiveObjects;
                    break;
                case GameStateAction.Defeat:
                    _gameState.OnDefeat -= SetActiveObjects;
                    break;
            }
        }

        private void SetActiveObjects()
        {
            Debug.Log($"Set {(_setActive ? "Active" : "Disable")} Objects on {_onGameState} action");
            foreach (var obj in _objects)
            {
                obj.gameObject.SetActive(_setActive);
            }
        }

        private enum GameStateAction
        {
            Victory,
            Defeat
        }
    }
}
