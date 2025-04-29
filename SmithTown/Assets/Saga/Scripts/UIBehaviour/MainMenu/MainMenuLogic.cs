using Saga.SceneService;
using Saga.UIBehaviour.SettingsMenu;
using UnityEngine;

namespace Saga.UIBehaviour.MainMenu
{
    public class MainMenuLogic : MonoBehaviour
    {
        [SerializeField] private SettingsMenuState settingsMenu;

        public void PlayGame()
        {
            SceneController.GoToGameScene();
        }

        public void OpenSettingsMenu()
        {
            Instantiate(settingsMenu);
        }
        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

