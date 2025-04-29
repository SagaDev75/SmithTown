using Saga.ResourceSystem.Recipes;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.UIBehaviour.RecipeUI
{
    public class RecipeWidget : MonoBehaviour
    {
        [SerializeField] private ItemUIGroup priceGroup;
        [SerializeField] private ItemUIGroup resultGroup;

        public void SetRecipe(RecipePreset preset)
        {
            if (!preset)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);
            
            priceGroup.ShowItems(preset.Price);
            resultGroup.ShowItems(preset.Reward);
        }
    }
}

