using System;
using Saga.BuildingSystem;
using Saga.BuildingSystem.Buildings;
using Saga.UIBehaviour.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingScreenLogicA : ScreenLogic
    {
        [SerializeField] private Transform widgetContainer;
        [FormerlySerializedAs("widgetPrefab")] [SerializeField] private SelectBuildingWidgetA widgetAPrefab;

        public void BuildWidgets(params Action<BuildingInfo>[] actions)
        {
            foreach (var branch in BuildingBranchStorage.Storage.Values)
            {
                var info = new BuildingInfo(branch);

                if (!info.IsUnblocked) continue;
                
                var widget = Instantiate(widgetAPrefab, widgetContainer);
                widget.SetInfo(info);
                widget.SetBuyingLogic(actions);
            }
        }
    }
}