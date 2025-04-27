using Saga.GameStateService.States;

namespace Saga.UIBehaviour.MainMenu
{
    public class MainMenuState : MonoGameStateBase
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

