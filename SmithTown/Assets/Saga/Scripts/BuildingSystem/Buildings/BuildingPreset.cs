using System.Linq;
using Saga.ProgressSystem;
using Saga.ResourceSystem;
using Saga.ResourceSystem.Recipes;
using UnityEngine;

namespace Saga.BuildingSystem.Buildings
{
    [CreateAssetMenu(menuName = "Saga/BuildingPreset")]
    public class BuildingPreset : ProgressContent
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject prefab;
        [SerializeField] private ResourceInfo[] price;
        [SerializeField] private RecipePreset[] recipes;

        public GameObject Prefab => prefab;
        public ResourceInfo[] Price => price.ToArray(); //copy
        public override Sprite Icon => icon;
        public RecipePreset[] Recipes => recipes.ToArray(); //copy
    }
}