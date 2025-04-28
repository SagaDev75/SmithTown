using System;
using Saga.BuildingSystem.Slot;
using Saga.ProgressSystem;
using Saga.ResourceSystem;

namespace Saga.GameSession.Session
{
    [Serializable]
    public class SessionData
    {
        public int sceneIndex;
        public bool tutorialCompleted;
        public ProgressInfo progressInfo;
        public ResourceSave[] resources;
        public SlotInfo[] buildingSlots;
    }
}