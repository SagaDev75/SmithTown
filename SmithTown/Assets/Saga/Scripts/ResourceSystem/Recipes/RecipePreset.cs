using System.Linq;
using UnityEngine;

namespace Saga.ResourceSystem.Recipes
{
    [CreateAssetMenu(fileName = "New Recipe", menuName = "Saga/Recipe")]
    public class RecipePreset : ScriptableObject
    {
        [SerializeField, Min(1)] private int duration;
        [SerializeField] private ResourceInfo[] price;
        [SerializeField] private ResourceInfo[] reward;
        
        public int Duration => duration;
        public ResourceInfo[] Price => price.ToArray();
        public ResourceInfo[] Reward => reward.ToArray();
    }
}

