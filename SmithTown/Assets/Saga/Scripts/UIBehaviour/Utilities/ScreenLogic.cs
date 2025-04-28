using System;
using UnityEngine;

namespace Saga.UIBehaviour.Utilities
{
    public class ScreenLogic : MonoBehaviour
    {
        public event Action OnClosed;
        
        public void CloseScreen()
        {
            OnClose();
            OnClosed?.Invoke();
            Destroy(gameObject);
        }
        protected virtual void OnClose()
        {
            
        }
    }
}
