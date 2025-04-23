using UnityEngine;
using UnityEngine.Events;

namespace Saga.GameStateService.States
{
    public class MonoGameStateBase : MonoBehaviour, IGameState
    {
        [SerializeField] private UnityEvent onActivation;
        [SerializeField] private UnityEvent onDeactivation;
        [SerializeField] private UnityEvent onRegistration;
        [SerializeField] private UnityEvent onUnregistration;
        
        protected void RegisterSelf()
        {
            GameStateMachine.RegisterState(this);
        }
        protected void UnregisterSelf()
        {
            GameStateMachine.UnregisterState(this);
        }
        
        protected virtual void OnStateActivation()
        {
            
        }
        protected virtual void OnStateDeactivation()
        {
            
        }
        protected virtual void OnStateRegistration()
        {
            
        }
        protected virtual void OnStateUnregistration()
        {
            
        }

        void IGameState.OnStateActivation()
        {
            OnStateActivation();
            onActivation?.Invoke();
        }
        void IGameState.OnStateDeactivation()
        {
            OnStateDeactivation();
            onDeactivation?.Invoke();
        }
        void IGameState.OnStateRegistration()
        {
            OnStateRegistration();
            onRegistration?.Invoke();
        }
        void IGameState.OnStateUnregistration()
        {
            OnStateUnregistration();
            onUnregistration?.Invoke();
        }
    }
}
