using System;
using Saga.BuildingSystem.Buildings;
using Saga.UIBehaviour.BuildingSettingsScreen;
using Saga.UIBehaviour.SelectBuildingScreen;
using UnityEngine;

namespace Saga.BuildingSystem.Slot
{
    public class BuildingSlot : MonoBehaviour
    {
        public const int OutLevel = -1;
        
        [SerializeField, HideInInspector] private string guid = Guid.NewGuid().ToString();

        [SerializeField] private BuildingSettingsScreenState settingsScreen;
        [SerializeField] private SelectBuildingScreenLogic selectScreen;
        [SerializeField] private Transform prefabContainer;
        
        private BuildingBranch _branch;
        private GameObject _prefab;
        private int _level = -1;

        public void OpenMenu()
        {
            if (_branch == null)
            {
                var select = Instantiate(selectScreen);
                select.BuildWidgets(
                    preset => SetBuilding(preset, 0),
                    _ => OpenMenu()
                    );
            }
            else
            {
                Instantiate(settingsScreen);
            }
        }

        public void SetBuilding(BuildingBranch branch, int level = OutLevel)
        {
            if(_prefab != null) Destroy(_prefab);
            _branch = branch;
            _level = level;
            if (branch == null) return;

            _prefab = Instantiate(branch.GetBuildingPreset(level).Prefab, prefabContainer);
        }
    }
}

