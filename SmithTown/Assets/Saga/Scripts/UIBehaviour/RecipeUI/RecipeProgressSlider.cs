using Saga.ResourceSystem.Recipes;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.RecipeUI
{
    public class RecipeProgressSlider : MonoBehaviour
    {
        [SerializeField] private Slider progressSlider;

        public void SetProgress(RecipeInfo info)
        {
            progressSlider.value = info.Percentage;
        }
    }
}

