using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _indexScene;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDestroy() 
            => _button.onClick.RemoveListener(LoadScene);

        private void LoadScene() => SceneManager.LoadScene(_indexScene);

    }
}