using Saga.GameStateService.States;

namespace Saga.UIBehaviour.OrderScreen
{
    public class OrderScreenState : MonoGameStateBase
    {
        private void Awake()
        {
            RegisterSelf();;
        }

        private void OnDestroy()
        {
            UnregisterSelf();
        }
    }
}

