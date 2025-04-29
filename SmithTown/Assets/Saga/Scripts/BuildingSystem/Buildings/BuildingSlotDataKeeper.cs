using System;
using System.Collections.Generic;
using System.Linq;
using Saga.BuildingSystem.Slot;
using Saga.GameSession.Session;
using Saga.SystemInitialization;

namespace Saga.BuildingSystem.Buildings
{
    public class BuildingSlotDataKeeper : MonoSessionService<BuildingSlotDataKeeper>
    {
        public static readonly SlotWrapper Wrapper = new();
        
        public static event Action<SlotWrapper> OnUpdating;
        public static event Action<SlotWrapper> OnCollecting;
        
        protected override void OnDataCollecting(SessionData data)
        {
            Wrapper.Clear();;
            
            OnCollecting?.Invoke(Wrapper);

            data.buildingSlots = Wrapper.GetArray();
        }
        protected override void OnDataUpdating(SessionData data)
        {
            foreach (var slot in data.buildingSlots)
            {
                Wrapper.ResetSlotInfo(slot);
            }
            
            OnUpdating?.Invoke(Wrapper);
        }
    }

    public class SlotWrapper
    {
        private readonly Dictionary<string, SlotInfo> _slotInfos = new();

        public bool TryGetSlotInfo(string slotName, out SlotInfo slotInfo)
        {
            return _slotInfos.TryGetValue(slotName, out slotInfo);
        }
        public void ResetSlotInfo(SlotInfo slotInfo)
        {
            _slotInfos[slotInfo.slotId] = slotInfo;
        }
        public SlotInfo[] GetArray()
        {
            return _slotInfos.Values.ToArray();
        }

        public void Clear()
        {
            _slotInfos.Clear();
        }
    }
}

