using System;
using Saga.Items.Presets;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.ResourceSystem
{
    public class ResourceData : IItem
    {
        public ResourcePreset Preset { get; }
        public int Count { get; private set; }
        public string Key => Preset.name;
        public Sprite Icon => Preset.Icon;
        public string Info => Count.ToString();
        
        public ResourceData(ResourceInfo info)
        {
            Preset = info.Preset;
            Count = info.Amount;
        }
        public ResourceData(ResourcePreset preset, int count = 0)
        {
            Preset = preset;
            Count = Math.Max(0, count);
        }

        public bool CheckAmount(int amount)
        {
            return Count >= amount;
        }
        public void Increase(int amount)
        {
            Count += amount;
        }
        public bool TrySpend(int amount)
        {
            if (!CheckAmount(amount)) return false;
            
            Count -= amount;
            if (Count < 0) Count = 0;
            return true;
        }
        public void Spend(int amount)
        {
            Count -= amount;
            if (Count < 0) Count = 0;
        }
        
        public static implicit operator ResourceInfo(ResourceData data)
        {
            return new ResourceInfo(data.Preset, data.Count);
        }
    }
}