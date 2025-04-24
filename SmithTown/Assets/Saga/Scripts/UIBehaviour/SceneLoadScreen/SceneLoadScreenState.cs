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
        
        private bool _isActive;
        public async void SetTasks(params Func<Task>[] taskFuncs)
        {
            RegisterSelf();
            _isActive = true;

            onProgress?.Invoke(0);
            
            var total = taskFuncs.Length;
            var completed = 0;

            foreach (var taskFunc in taskFuncs)
            {
                await taskFunc();
                completed++;

                var progress = (float)completed / total;
                onProgress?.Invoke(progress);
            }
        }

        private void OnDestroy()
        {
            if(_isActive) UnregisterSelf();
        }
    }
}

