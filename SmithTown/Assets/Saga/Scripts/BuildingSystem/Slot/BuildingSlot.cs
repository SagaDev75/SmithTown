using System;
using Saga.BuildingSystem.Buildings;
using Saga.ResourceSystem.Recipes;
using Saga.UIBehaviour.BuildingSettingsScreen;
using Saga.UIBehaviour.SelectBuildingScreen;
using UnityEngine;

namespace Saga.BuildingSystem.Slot
{
    [RequireComponent(typeof(SlotWorkshop))]
    public class BuildingSlot : MonoBehaviour
    {
        [SerializeField] private string guid;
        [SerializeField] private SlotWorkshop slotWorkshop;
        [SerializeField] private BuildingSettingsScreenLogic settingsScreen;
        [SerializeField] private SelectBuildingScreenLogicA selectScreen;
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
                settings.SetDestroyLogic(
                    SetBuilding,
                    _ => OpenMenu(), 
                    _ => settings.CloseScreen(),
                    _ => slotWorkshop.recipeInfo = new RecipeInfo());
                settings.SetRecipeProgress(slotWorkshop.recipeInfo);

                if (_buildingInfo.TryGetPreset(out var preset))
                {
                    settings.BuildRecipeWidgets(preset,
                        recipePreset => slotWorkshop.recipeInfo = new RecipeInfo()
                        {
                            preset = recipePreset,
                            step = 0,
                        },
                        _ => OpenMenu(), 
                        _ => settings.CloseScreen());
                }
            }
        }
        private void SetBuilding(BuildingInfo info)
        {
            if(_prefab) Destroy(_prefab);
            _buildingInfo = info;
            if (!info.TryGetPreset(out var preset)) return;

            _prefab = Instantiate(preset.Prefab, prefabContainer);
        }

        private void Awake()
        {
            BuildingSlotDataKeeper.OnUpdating += OnDataUpdating;
            BuildingSlotDataKeeper.OnCollecting += OnCollecting;
            
            OnDataUpdating(BuildingSlotDataKeeper.Wrapper);
        }
        private void OnDestroy()
        {
            BuildingSlotDataKeeper.OnUpdating -= OnDataUpdating;
            BuildingSlotDataKeeper.OnCollecting -= OnCollecting;
        }

        private void OnCollecting(SlotWrapper wrapper)
        {
            SlotInfo slotInfo = new()
            {
                slotId = guid,
                branchKey = _buildingInfo.Branch?.name,
                level = _buildingInfo.Level,
                recipeKey = slotWorkshop.recipeInfo.preset?.name,
                recipeProgress = slotWorkshop.recipeInfo.step,
            };
            
            wrapper.ResetSlotInfo(slotInfo);
        }
        private void OnDataUpdating(SlotWrapper wrapper)
        {
            if (!wrapper.TryGetSlotInfo(guid, out var info)) return;
            
            BuildingInfo buildingInfo = new(BuildingBranchStorage.Storage[info.branchKey], info.level);
            SetBuilding(buildingInfo);
            RecipeInfo recipeInfo = new()
            {
                preset = RecipePresetStorage.Storage[info.recipeKey],
                step = info.recipeProgress,
            };
            slotWorkshop.recipeInfo = recipeInfo;
        }

        [ContextMenu("Recreate Guid")]
        private void RecreateGuid()
        {
            guid = Guid.NewGuid().ToString();
        }
    }
}

