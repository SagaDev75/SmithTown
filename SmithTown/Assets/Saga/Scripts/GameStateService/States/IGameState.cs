namespace Saga.GameStateService.States
{
    public interface IGameState
    {
        public void OnStateActivation();
        public void OnStateDeactivation();
        public void OnStateRegistration();
        public void OnStateUnregistration();
    }
}
