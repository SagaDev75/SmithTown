using System;
using Saga.SystemInitialization;

namespace Saga.GameSession.Session
{
    public class UserSessionKeeper : MonoSingleton<UserSessionKeeper>
    {
        private SessionData _data;

        public static event Action<SessionData> OnSessionDataUpdated;
        
        public static SessionData Data
        {
            get => Singleton._data;
            set
            {
                Singleton._data = value;
                OnSessionDataUpdated?.Invoke(value);
            }
        }
    }
}