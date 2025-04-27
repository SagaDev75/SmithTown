using System;
using Saga.SystemInitialization;

namespace Saga.GameSession.Session
{
    public class SessionDataController : MonoSingleton<SessionDataController>
    {
        public static event Action<SessionData> OnDataUpdating;
        public static event Action<SessionData> OnDataCollecting;

        public static void UpdateData(SessionData data)
        {
            OnDataUpdating?.Invoke(data);
        }
        public static SessionData CollectData()
        {
            var sessionData = new SessionData();
            
            OnDataCollecting?.Invoke(sessionData);

            return sessionData;
        }
    }
}