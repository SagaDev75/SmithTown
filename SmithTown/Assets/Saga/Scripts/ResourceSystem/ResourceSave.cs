using System;
using UnityEngine;

namespace Saga.ResourceSystem
{
    [Serializable]
    public struct ResourceSave
    {
        [SerializeField] private string name;
        [SerializeField] private int amount;
        
        public string ResourceName => name;
        public int ResourceAmount => amount;
        
        public ResourceSave(ResourceData resourceData)
        {
            name = resourceData.Name;
            amount = resourceData.Count;
        }
        
        public ResourceSave(ResourceInfo info)
        {
            name = info.Preset.name;
            amount = info.Amount;
        }
    }
}

