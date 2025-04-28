using Saga.UIBehaviour.TutorialScreen;
using UnityEngine;

namespace Saga.Tutorial
{
    public class TutorialActivator : MonoBehaviour
    {
        [SerializeField] private TutorialScreenLogic tutorialScreenLogic;

        public void Start()
        {
            if(TutorialManager.completed) return;
            
            Instantiate(tutorialScreenLogic);
        }
    }
}