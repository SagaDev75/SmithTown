using System;
using Saga.BuildingSystem;
using Saga.UIBehaviour.BuildingMenu;
using Saga.UIBehaviour.Utilities;
using UnityEngine;

namespace Saga.UIBehaviour.BuildingSettingsScreen
{
    public class BuildingSettingsScreenLogic : ScreenLogic
    {
        [SerializeField] private BuyBuildingWidget buyingWidget;
        
        private BuildingInfo _info;
        
        public void SetBuilding(BuildingInfo info, params Action<BuildingInfo>[] upgradeActions)
        {
            _info = info;

            if (info.TryGetNextPreset(out _))
            {
                buyingWidget.gameObject.SetActive(true);
                var nextInfo = _info;
                nextInfo.Level++;
                buyingWidget.SetInfo(nextInfo);
                foreach (var act in upgradeActions)
                {
                    buyingWidget.OnBuildingBought += act;
                }
            }
            else
            {
                buyingWidget.gameObject.SetActive(false);
            }
        }
    }
}