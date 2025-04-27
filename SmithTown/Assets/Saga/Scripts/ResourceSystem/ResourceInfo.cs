using System;
using Saga.Items.Presets;
using UnityEngine;

namespace Saga.ResourceSystem
{
    [Serializable]
    public struct ResourceInfo
    {
        [SerializeField] private ResourcePreset preset;
        [SerializeField, Min(0)] private int amount;

        public ResourcePreset Preset => preset;
        public int Amount => amount;
        public string Key => preset.name;
        
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

