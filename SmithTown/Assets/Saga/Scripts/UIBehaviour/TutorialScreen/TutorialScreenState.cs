using Saga.GameStateService.States;

namespace Saga.UIBehaviour.TutorialScreen
{
    public class TutorialScreenState : MonoGameStateBase
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

