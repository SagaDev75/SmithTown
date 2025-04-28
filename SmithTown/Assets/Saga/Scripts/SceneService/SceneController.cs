using System;
using System.Threading.Tasks;
using Saga.GameSession.Session;
using Saga.SystemInitialization;
using Saga.UIBehaviour.SceneLoadScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Saga.SceneService
{
    public class SceneController : MonoSessionService<SceneController>
    {
        [SerializeField] private int mainMenuIndex = 0;
        [SerializeField] private int loadingSceneIndex = 1;
        [SerializeField] private int firstSceneIndex = 2;
        [SerializeField] private int lastSceneIndex = 3;
        
        private static int _currentSceneIndex;
        
        protected override void OnDataUpdating(SessionData data)
        {
            _currentSceneIndex = data.sceneIndex;
        }
        protected override void OnDataCollecting(SessionData data)
        {
            data.sceneIndex = _currentSceneIndex;
        }
        
        public static async void GoToMainMenu()
        {
            await SessionDataLoader.Save();
            SceneManager.LoadScene(Singleton.mainMenuIndex);
        }
        public static void GoToGameScene()
        {
            if (_currentSceneIndex < Singleton.firstSceneIndex) _currentSceneIndex = Singleton.firstSceneIndex;
            
            OpenLoadingScene();
            SceneLoadScreenState.SetTasks(() => Task.Delay(200), 
                () => Task.Delay(200), 
                () => Task.Delay(500), 
                () => Task.Delay(100),
                SessionDataLoader.Load, 
                () => Task.Delay(100), 
                () => Task.Delay(150), 
                () => Task.Delay(200),
                () => LoadSceneAsyncTask(_currentSceneIndex));
        }
        public static async void GoToNextGameScene()
        {
            if (_currentSceneIndex >= Singleton.lastSceneIndex)
            {
                GoToMainMenu();
                return;
            }

            _currentSceneIndex++;
            await SessionDataLoader.Save();
            GoToGameScene();
        }

        private static void OpenLoadingScene()
        {
            SceneManager.LoadScene(Singleton.loadingSceneIndex, LoadSceneMode.Single);
        }
        private static Task LoadSceneAsyncTask(int index)
        {
            var tcs = new TaskCompletionSource<bool>();
            var operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);

            if (operation != null) operation.completed += _ => tcs.SetResult(true);
            else throw new ArgumentException("Invalid scene index");
            return tcs.Task;
        }
    }
}

