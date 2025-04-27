using Saga.GameStateService.States;

public class ResourceScreenState : MonoGameStateBase
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
