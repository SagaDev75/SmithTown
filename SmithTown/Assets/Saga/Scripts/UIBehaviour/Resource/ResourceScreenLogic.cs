using System.Linq;
using Saga.ResourceSystem;
using UnityEngine;

namespace Saga.UIBehaviour.Resource
{
    public class ResourceScreenLogic : MonoBehaviour
    {
        [SerializeField] private ResourceGroup group;

        private void Start()
        {
            group.Show(ResourceManager.Resources.Values.ToArray());
        }

        public void CloseMenu()
        {
            Destroy(gameObject);
        }
    }
}

