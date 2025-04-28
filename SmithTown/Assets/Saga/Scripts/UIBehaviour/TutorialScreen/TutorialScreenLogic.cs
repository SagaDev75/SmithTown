using Saga.ResourceSystem;
using Saga.Tutorial;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.UIBehaviour.TutorialScreen
{
    public class TutorialScreenLogic : MonoBehaviour
    {
        [SerializeField] private ItemUIGroup group;

        private void Awake()
        {
            group.ShowItems(TutorialManager.TutorialResources);
        }

        public void CloseScreen()
        {
            ResourceManager.AddResources(TutorialManager.TutorialResources);
            TutorialManager.completed = true;
            Destroy(gameObject);
        }
    }
}