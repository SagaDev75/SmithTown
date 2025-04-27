using System.Collections.Generic;
using Saga.ResourceSystem;
using UnityEngine;

namespace Saga.BuildingSystem.Buildings
{
    [CreateAssetMenu(menuName = "Saga/BuildingPreset")]
    public class BuildingPreset : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private ResourceInfo[] price;
        public GameObject Prefab => prefab;
        public IEnumerable<ResourceInfo> Price => price;
    }
}