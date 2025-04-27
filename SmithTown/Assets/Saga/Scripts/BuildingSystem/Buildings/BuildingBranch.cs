using System.Collections.Generic;
using UnityEngine;

namespace Saga.BuildingSystem.Buildings
{
    [CreateAssetMenu(menuName = "Saga/BuildingBranch")]
    public class BuildingBranch : ScriptableObject
    {
        [SerializeField] private BuildingPreset[] buildingLevels;

        public BuildingPreset GetBuildingPreset(int level)
        {
            return buildingLevels[level];
        }
    }
}

