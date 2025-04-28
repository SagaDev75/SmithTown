using System.Linq;
using Saga.ResourceSystem;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.UIBehaviour.Resource
{
    public class ResourceScreenLogic : MonoBehaviour
    {
        [SerializeField] private ItemUIGroup group;

        private void Start()
        {
            group.ShowItems(ResourceManager.Resources.Values.ToArray());
        }

        public void CloseMenu()
        {
            Destroy(gameObject);
        }
    }
}

