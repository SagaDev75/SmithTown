using System;
using System.Threading.Tasks;
using Saga.GameSession.Session;
using Saga.GameSession.Settings;
using Saga.UIBehaviour.SceneLoadScreen;
using Saga.UIBehaviour.SettingsMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Saga.UIBehaviour.MainMenu
{
    public class MainMenuLogic : MonoBehaviour
    {
        [SerializeField] private int mainSceneIndex;
        [SerializeField] private SettingsMenuState settingsMenu;
        [SerializeField] private SceneLoadScreenState sceneLoadScreen;

        public void PlayGame()
        {
            var screen = Instantiate(sceneLoadScreen);
            
            screen.SetTasks(
                () => Task.Delay(200), 
                () => Task.Delay(200), 
                () => Task.Delay(500), 
                () => Task.Delay(100),
                SessionDataLoader.Load, 
                () => Task.Delay(100), 
                () => Task.Delay(150), 
                () => Task.Delay(200),
                () => LoadSceneAsyncTask(mainSceneIndex));
            return;

            static Task LoadSceneAsyncTask(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single)
            {
                var tcs = new TaskCompletionSource<bool>();
                var operation = SceneManager.LoadSceneAsync(sceneIndex, mode);

                if (operation != null) operation.completed += _ => tcs.SetResult(true);
                else throw new ArgumentException("Invalid scene index");
                return tcs.Task;
            }
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

