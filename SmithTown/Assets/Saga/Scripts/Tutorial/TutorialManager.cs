using Saga.GameSession.Session;
using Saga.ResourceSystem;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.Tutorial
{
    public class TutorialManager : MonoSessionService<TutorialManager>
    {
        [SerializeField] private ResourceInfo[] tutorialResources;
        
        public static ResourceInfo[] TutorialResources => Singleton.tutorialResources;
        public static bool Completed { get; set; }

        protected override void OnDataCollecting(SessionData data)
        {
            data.tutorialCompleted = Completed;
        }
        protected override void OnDataUpdating(SessionData data)
        {
            Completed = data.tutorialCompleted;
        }
    }
}

