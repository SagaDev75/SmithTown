using System;
using System.Threading.Tasks;
using Saga.GameStateService.States;
using UnityEngine;
using UnityEngine.Events;

namespace Saga.UIBehaviour.SceneLoadScreen
{
    public class SceneLoadScreenState : MonoGameStateBase
    {
        [SerializeField] private UnityEvent<float> onProgress;

        private static SceneLoadScreenState I;
        
        public static async void SetTasks(params Func<Task>[] taskFuncs)
        {
            var total = taskFuncs.Length;
            var completed = 0;

            foreach (var taskFunc in taskFuncs)
            {
                await taskFunc();
                completed++;

                var progress = (float)completed / total;
                I.onProgress?.Invoke(progress);
            }
        }

        private void Awake()
        {
            I = this;
            RegisterSelf();
        }
        private void OnDestroy()
        {
            UnregisterSelf();
        }
    }
}

