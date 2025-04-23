using UnityEngine;

namespace Saga.SystemInitialization
{
    public class MonoSingleton<T> : MonoSystem
            where T : MonoSingleton<T>
    {
        protected static T Singleton { get; private set; }

        private void Awake()
        {
            if (Singleton == null)
            {
                Singleton = this as T;
                OnAwake();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log(SystemInitializer.MessagePrefix + "Attempting to initialize a duplicate system: " + typeof(T).Name);
                Destroy(gameObject);
            }
        }
    
        protected virtual void OnAwake()
        {
        
        }
    }
}

