using System;
using UnityEngine;

namespace Saga.ResourceSystem
{
    [Serializable]
    public struct ResourceSave
    {
        [SerializeField] private string key;
        [SerializeField] private int amount;
        
        public string ResourceKey => key;
        public int ResourceAmount => amount;
        
        public ResourceSave(ResourceInfo info)
        {
            key = info.Preset.name;
            amount = info.Amount;
        }
    }
}

