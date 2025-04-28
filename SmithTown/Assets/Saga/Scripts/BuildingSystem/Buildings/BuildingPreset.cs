using System.Linq;
using Saga.ProgressSystem;
using Saga.ResourceSystem;
using UnityEngine;

namespace Saga.BuildingSystem.Buildings
{
    [CreateAssetMenu(menuName = "Saga/BuildingPreset")]
    public class BuildingPreset : ProgressContent
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject prefab;
        [SerializeField] private ResourceInfo[] price;

        public GameObject Prefab => prefab;
        public ResourceInfo[] Price => price.ToArray(); //copy
        public Sprite Icon => icon;
    }
}