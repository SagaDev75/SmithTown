using System;
using Saga.GameTickService;
using Saga.ResourceSystem;
using Saga.ResourceSystem.Recipes;
using UnityEngine;
using UnityEngine.Events;

namespace Saga.BuildingSystem.Slot
{
    public class SlotWorkshop : MonoBehaviour
    {
        [SerializeField] private UnityEvent<RecipeInfo> OnTick;
        [NonSerialized] public RecipeInfo recipeInfo;
        
        private void Awake()
        {
            GameTickMachine.BeforeTick += WorkshopProcess;
        }
        private void OnDestroy()
        {
            GameTickMachine.BeforeTick -= WorkshopProcess;
        }

        private void WorkshopProcess()
        {
            OnTick?.Invoke(recipeInfo);
            
            if(!recipeInfo.preset) return;

            if(recipeInfo.step == 0 && !ResourceManager.TrySpendResources(recipeInfo.preset.Price)) return;
            
            recipeInfo.step++;

            if (recipeInfo.Percentage <= 1) return;
            
            ResourceManager.AddResources(recipeInfo.preset.Reward);
            recipeInfo.step = 0;
        }
    }
}

