using Saga.ResourceSystem;
using Saga.UIBehaviour.Resource;
using UnityEngine;

namespace Saga.UIBehaviour.TutorialScreen
{
    public class TutorialScreenLogic : MonoBehaviour
    {
        [SerializeField] private ResourceGroup group;
        [SerializeField] private ResourceInfo[] rewards;

        private void Awake()
        {
            group.Show(rewards);
        }

        public void CloseScreen()
        {
            ResourceManager.AddResources(rewards);
            
            Destroy(gameObject);
        }
    }
}