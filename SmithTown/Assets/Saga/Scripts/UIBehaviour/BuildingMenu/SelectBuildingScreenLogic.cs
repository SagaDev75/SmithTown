using System;
using Saga.BuildingSystem;
using Saga.BuildingSystem.Buildings;
using Saga.UIBehaviour.Utilities;
using UnityEngine;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingScreenLogic : ScreenLogic
    {
        [SerializeField] private Transform widgetContainer;
        [SerializeField] private SelectBuildingWidget widgetPrefab;

        public void BuildWidgets(params Action<BuildingInfo>[] actions)
        {
            foreach (var branch in BuildingBranchStorage.Storage.Values)
            {
                var info = new BuildingInfo(branch);

                if (!info.IsUnblocked) continue;
                
                var widget = Instantiate(widgetPrefab, widgetContainer);
                widget.SetInfo(info);
                widget.SetBuyingLogic(actions);
            }
        }
    }
}