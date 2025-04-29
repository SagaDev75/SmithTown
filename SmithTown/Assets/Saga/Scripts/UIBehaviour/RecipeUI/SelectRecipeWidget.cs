using System;
using Saga.ResourceSystem.Recipes;
using UnityEngine;

namespace Saga.UIBehaviour.RecipeUI
{
    public class SelectRecipeWidget : MonoBehaviour
    {
        [SerializeField] private RecipeWidget recipeWidget;
        
        private event Action<RecipePreset> OnRecipeSelected;
        private RecipePreset _recipe;
        
        public void SetRecipe(RecipePreset info, params Action<RecipePreset>[] selectActions)
        {
            _recipe = info;
            recipeWidget.SetRecipe(info);

            OnRecipeSelected = null;
            
            foreach (var act in selectActions)
            {
                OnRecipeSelected += act;
            }
        }
        public void InvokeSelection()
        {
            OnRecipeSelected?.Invoke(_recipe);
        }
    }
}

