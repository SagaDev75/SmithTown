using Saga.GameStateService.States;
using Saga.GameTickService;

namespace Saga.GameplayLogic
{
    public class GameplayState : MonoGameStateBase
    {
        protected override void OnStateRegistration()
        {
            GameTickMachine.Mode = true;
        }
        protected override void OnStateUnregistration()
        {
            GameTickMachine.Mode = false;
        }

        private void Awake()
        {
            RegisterSelf();
        }

        private void OnDestroy()
        {
            UnregisterSelf();
        }
    }
}

