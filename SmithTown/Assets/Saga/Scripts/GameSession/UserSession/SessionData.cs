using System;
using Saga.BuildingSystem.Slot;
using Saga.ProgressSystem;
using Saga.ResourceSystem;

namespace Saga.GameSession.Session
{
    [Serializable]
    public class SessionData
    {
        public ProgressInfo progressInfo; //Dont drop it
        
        public int sceneIndex;
        public bool tutorialCompleted;
        public ResourceSave[] resources;
        public SlotInfo[] buildingSlots;
        public string[] orderKeys;
    }
}