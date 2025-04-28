using System;
using UnityEngine;

namespace Saga.BuildingSystem.Buildings
{
    [CreateAssetMenu(menuName = "Saga/BuildingBranch")]
    public class BuildingBranch : ScriptableObject
    {
        [SerializeField] private BuildingPreset[] buildingLevels;
        
        public bool TryGetPreset(int level, out BuildingPreset result)
        {
            if (level >= 0 && level < buildingLevels.Length)
            {
                result = buildingLevels[level];
                return true;
            }

            result = null;
            return false;
        }
    }
}

