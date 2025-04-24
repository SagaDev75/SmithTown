using System;
using System.Collections.Generic;
using Saga.GameStateService.States;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.GameStateService
{
    public class GameStateMachine : MonoSingleton<GameStateMachine>
    {
        private const string Code = "[GSM]";

        private IGameState _currentState;
        private readonly List<IGameState> _queueList = new();
        private readonly HashSet<IGameState> _queueHashSet = new();
        
        public static IGameState CurrentState
        {
            get => Singleton._currentState;
            private set
            {
                if(Singleton._currentState == value) return;
                
                if (Singleton._currentState != null)
                {
                    Singleton._currentState.OnStateDeactivation();
                    InnerOnStateChange?.Invoke(Singleton._currentState, GameStatePhase.Deactivation);
                }

                if (value != null)
                {
                    value.OnStateActivation();
                    InnerOnStateChange?.Invoke(value, GameStatePhase.Activation);
                }
                
                Singleton._currentState = value;
            }
        }
        
        private static event Action<IGameState, GameStatePhase> InnerOnStateChange;
        public static event Action<IGameState, GameStatePhase> OnStateChange
        {
            add
            {
                if (CurrentState != null) value(CurrentState, GameStatePhase.Activation);
                
                foreach (var state in Singleton._queueList)
                {
                    value(state, GameStatePhase.Registration);
                }
                
                InnerOnStateChange += value;
            }
            remove => InnerOnStateChange -= value;
        }

        public static void RegisterState(IGameState gameState)
        {
            CheckStateNullException(gameState);
            if (!TryAddStateToQueue(gameState))
            {
                Debug.LogWarning(BuildMessage("Attempt to add a state that is already in the queue"));
                return;
            }

            gameState.OnStateRegistration();
            InnerOnStateChange?.Invoke(gameState, GameStatePhase.Registration);
            ChangeCurrentState();
        }
        public static void UnregisterState(IGameState gameState)
        {
            CheckStateNullException(gameState);
            if(!TryRemoveStateFromQueue(gameState))
            {
                Debug.LogWarning(BuildMessage("Attempt to remove a state that is not in the queue"));
                return;
            }
            gameState.OnStateUnregistration();
            InnerOnStateChange?.Invoke(gameState, GameStatePhase.Unregistration);
            ChangeCurrentState();
        }
        private static void ChangeCurrentState()
        {
            if (Singleton._queueList.Count == 0)
            {
                CurrentState = null;
                return;
            }
            
            var nextState = Singleton._queueList[^1];
            CheckStateNullException(nextState, "The state was destroyed but not removed from the queue");
            CurrentState = nextState;
        }

        private static bool TryAddStateToQueue(IGameState gameState)
        {
            CheckStateNullException(gameState);
            
            if (!Singleton._queueHashSet.Add(gameState)) return false;
            Singleton._queueList.Add(gameState);
            return true;
        }
        private static bool TryRemoveStateFromQueue(IGameState gameState)
        {
            CheckStateNullException(gameState);
            
            return Singleton._queueHashSet.Remove(gameState) 
                   && Singleton._queueList.Remove(gameState);
        }

        private static string BuildMessage(string message)
        {
            return Code + " " + message;
        }
        private static void CheckStateNullException(IGameState gameState, string message = "State cannot be null.")
        {
            if (gameState == null) throw new ArgumentNullException(nameof(gameState), BuildMessage(message));
        }
    }
}
