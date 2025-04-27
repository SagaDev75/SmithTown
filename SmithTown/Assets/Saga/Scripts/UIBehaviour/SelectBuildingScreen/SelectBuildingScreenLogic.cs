using System;
using Saga.BuildingSystem.Buildings;
using Saga.BuildingSystem.Slot;
using UnityEngine;
using UnityEngine.Events;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingScreenLogic : MonoBehaviour
    {
        [SerializeField] private Transform widgetContainer;
        [SerializeField] private SelectBuildingWidget widgetPrefab;
        
        [NonSerialized] public BuildingSlot Slot;
        
        public void CloseWindow()
        {
            Destroy(gameObject);
        }

        public void BuildWidgets(params Action<BuildingBranch>[] actions)
        {
            foreach (var preset in BuildingBranchStorage.Storage.Values)
            {
                var widget = Instantiate(widgetPrefab, widgetContainer);
                widget.SetBuildingPreset(preset);
                foreach (var action in actions)
                {
                    widget.OnBuildingSelected += action;
                    widget.OnBuildingSelected += _ => CloseWindow();
                }
            }
        }
    }
}