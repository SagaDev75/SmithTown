using Saga.ResourceSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Saga.UIBehaviour.Utilities
{
    public class ResourceEnoughEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnoughResources;
        [SerializeField] private UnityEvent onNotEnoughResources;

        public void CheckResources(params ResourceInfo[] infos)
        {
            if(ResourceManager.CheckResources(infos)) onEnoughResources.Invoke();
            else onNotEnoughResources.Invoke();
        }
    }
}

