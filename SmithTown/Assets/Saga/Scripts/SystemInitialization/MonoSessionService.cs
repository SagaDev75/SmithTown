using Saga.GameSession.Session;

namespace Saga.SystemInitialization
{
    public class MonoSessionService<T> : MonoSingleton<T>
        where T : MonoSessionService<T>
    {
        protected virtual void Start()
        {
            SessionDataController.OnDataCollecting += OnDataCollecting;
            SessionDataController.OnDataUpdating += OnDataUpdating;
        }
        
        protected virtual void OnDataUpdating(SessionData data)
        {
        }
        protected virtual void OnDataCollecting(SessionData data)
        {
        }
    }
}

