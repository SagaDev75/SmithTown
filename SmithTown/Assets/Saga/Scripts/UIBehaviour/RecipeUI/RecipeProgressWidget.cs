using Saga.ResourceSystem.Recipes;
using UnityEngine;

namespace Saga.UIBehaviour.RecipeUI
{
    public class RecipeProgressWidget : MonoBehaviour
    {
        [SerializeField] private RecipeProgressSlider progressSlider;
        [SerializeField] private RecipeWidget recipeWidget;

        public void SetRecipeProgress(RecipeInfo info)
        {
            //progressSlider.SetProgress(info);
            recipeWidget.SetRecipe(info.preset);
        }
    }
}