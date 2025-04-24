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

        protected override void OnStateActivation()
        {
            gameObject.SetActive(true);
        }
        protected override void OnStateDeactivation()
        {
            gameObject.SetActive(false);
        }
    }
}

