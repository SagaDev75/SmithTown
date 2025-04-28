using Saga.GameStateService.States;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingScreenState : MonoGameStateBase
    {
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

