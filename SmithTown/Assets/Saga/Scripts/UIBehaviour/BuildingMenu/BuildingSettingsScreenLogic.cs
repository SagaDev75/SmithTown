using System;
using Saga.BuildingSystem;
using Saga.BuildingSystem.Buildings;
using Saga.ResourceSystem.Recipes;
using Saga.UIBehaviour.BuildingMenu;
using Saga.UIBehaviour.RecipeUI;
using Saga.UIBehaviour.Utilities;
using UnityEngine;

namespace Saga.UIBehaviour.BuildingSettingsScreen
{
    public class BuildingSettingsScreenLogic : ScreenLogic
    {
        [SerializeField] private BuyBuildingWidget buyingWidget;
        [SerializeField] private SelectRecipeWidget selectRecipeWidgetPrefab;
        [SerializeField] private RecipeProgressWidget recipeWidget;
        [SerializeField] private Transform selectRecipeContainer;
        
        private BuildingInfo _info;
        private event Action<BuildingInfo> OnDestroyButtonClicked;
        public void SetBuilding(BuildingInfo info, params Action<BuildingInfo>[] upgradeActions)
        {
            _info = info;

            if (info.TryGetNextPreset(out var next) && next.Unbloked)
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
        public void SetDestroyLogic(params Action<BuildingInfo>[] destroyActions)
        {
            OnDestroyButtonClicked = null;
            
            foreach (var act in destroyActions)
            {
                OnDestroyButtonClicked += act;
            }
        }
        public void SetRecipeProgress(RecipeInfo info)
        {
            recipeWidget.SetRecipeProgress(info);
        }
        public void BuildRecipeWidgets(BuildingPreset building, params Action<RecipePreset>[] selectActions)
        {
            foreach (var recipe in building.Recipes)
            {
                CreateWidget(recipe, selectActions);
            }
        }
        
        private SelectRecipeWidget CreateWidget(RecipePreset preset, params Action<RecipePreset>[] selectActions)
        {
            var widget = Instantiate(selectRecipeWidgetPrefab, selectRecipeContainer);
            widget.SetRecipe(preset, selectActions);
            return widget;
        }
        public void InvokeDestroyButtonLogic()
        {
            var info = new BuildingInfo(null);
            
            OnDestroyButtonClicked?.Invoke(info);
        }
    }
}