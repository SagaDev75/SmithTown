using System;

namespace Saga.BuildingSystem.Slot
{
    [Serializable]
    public struct SlotInfo
    {
        public string slotId;
        public string branchKey;
        public int level;
        public string recipeKey;
        public int recipeProgress;
    }
}

