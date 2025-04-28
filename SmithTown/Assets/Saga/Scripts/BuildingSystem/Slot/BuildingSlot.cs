using System;
using Saga.UIBehaviour.BuildingSettingsScreen;
using Saga.UIBehaviour.SelectBuildingScreen;
using UnityEngine;

namespace Saga.BuildingSystem.Slot
{
    public class BuildingSlot : MonoBehaviour
    {
        [SerializeField, HideInInspector] private string guid = Guid.NewGuid().ToString();

        [SerializeField] private BuildingSettingsScreenLogic settingsScreen;
        [SerializeField] private SelectBuildingScreenLogic selectScreen;
        [SerializeField] private Transform prefabContainer;
        
        private BuildingInfo _buildingInfo;
        private GameObject _prefab;

        public void OpenMenu()
        {
            if (!_buildingInfo.Branch)
            {
                var screen = Instantiate(selectScreen);
                screen.BuildWidgets(
                    SetBuilding,
                    _ => OpenMenu(),
                    _ => screen.CloseScreen());
            }
            else
            {
                var settings = Instantiate(settingsScreen);
                settings.SetBuilding(_buildingInfo, 
                    SetBuilding, 
                    _ => OpenMenu(), 
                    _ => settings.CloseScreen());
            }
        }
        public void SetBuilding(BuildingInfo info)
        {
            if(_prefab) Destroy(_prefab);
            _buildingInfo = info;
            if (!info.TryGetPreset(out var preset)) return;

            _prefab = Instantiate(preset.Prefab, prefabContainer);
        }
    }
}

