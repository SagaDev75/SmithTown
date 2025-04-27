using System;
using Saga.Items.Presets;

namespace Saga.ResourceSystem
{
    public class ResourceData
    {
        public string Name { get; }
        public int Count { get; private set; }
        public ResourcePreset Preset { get; }

        public event Action<int> OnCountChanged;
        public ResourceData(ResourceInfo info)
        {
            Preset = info.Preset;
            Name = Preset.name;
            Count = info.Amount;
        }

        public bool CheckAmount(int amount)
        {
            return Count >= amount;
        }
        public void Spend(int amount)
        {
            Count -= amount;
            if (Count < 0) Count = 0;
            OnCountChanged?.Invoke(Count);
        }
        public void Increase(int amount)
        {
            Count += amount;
            OnCountChanged?.Invoke(Count);
        }
        
        public static implicit operator ResourceInfo(ResourceData data)
        {
            return new ResourceInfo(data.Preset, data.Count);
        }
    }
}