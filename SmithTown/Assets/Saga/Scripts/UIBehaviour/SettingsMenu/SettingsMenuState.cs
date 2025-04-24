using Saga.GameStateService.States;

namespace Saga.UIBehaviour.SettingsMenu
{
    public class SettingsMenuState : MonoGameStateBase
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

