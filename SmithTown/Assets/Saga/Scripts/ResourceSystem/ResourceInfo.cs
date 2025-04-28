using System;
using Saga.Items.Presets;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.ResourceSystem
{
    [Serializable]
    public struct ResourceInfo : IItem
    {
        [SerializeField] private ResourcePreset preset;
        [SerializeField, Min(0)] private int amount;

        public ResourcePreset Preset => preset;
        public int Amount => amount;
        public string Key => preset.name;
        public Sprite Icon => preset.Icon;
        public string Info => amount.ToString();
        
        public ResourceInfo(ResourcePreset preset, int amount = 0)
        {
            this.preset = preset;
            this.amount = amount;
        }
        public static implicit operator string(ResourceInfo info)
        {
            return info.Key;
        }
    }
}

