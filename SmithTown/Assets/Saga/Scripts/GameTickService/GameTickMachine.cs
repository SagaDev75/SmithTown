using System;
using System.Collections;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.GameTickService
{
    public class GameTickMachine : MonoSingleton<GameTickMachine>
    {
        [SerializeField] private float tickInterval = 1f;
        private Coroutine _tickRoutine;
        
        public static event Action BeforeTick;
        public static event Action GameTick;
        public static event Action AfterTick;
        public static float TickInterval => Singleton.tickInterval;

        public static bool Mode
        {
            get => Singleton.enabled;
            set
            {
                if(Singleton == null) return;
                Singleton.enabled = value;
            }
        }

        private void OnEnable()
        {
            if(_tickRoutine != null) StopCoroutine(_tickRoutine);
            _tickRoutine = StartCoroutine(InvokeTick());
        }
        private void OnDisable()
        {
            if (_tickRoutine != null)
            {
                StopCoroutine(_tickRoutine);
                _tickRoutine = null;
            }
        }

        private IEnumerator InvokeTick()
        {
            while (true)
            {
                yield return new WaitForSeconds(tickInterval);
                BeforeTick?.Invoke();
                GameTick?.Invoke();
                AfterTick?.Invoke();
            }
        }
    } 
}

