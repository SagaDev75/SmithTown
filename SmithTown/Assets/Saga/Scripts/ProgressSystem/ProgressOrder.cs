using Saga.ResourceSystem;
using UnityEngine;

namespace Saga.ProgressSystem
{
    [CreateAssetMenu(fileName = "ProgressOrder", menuName = "Saga/ProgressOrder")]
    public class ProgressOrder : ScriptableObject
    {
        [SerializeField] private string label;
        [SerializeField] private string description;
        [SerializeField] private Sprite sprite;
        [SerializeField] private ResourceInfo[] target;
        
        public Sprite Icon => sprite;
        public ResourceInfo[] Target => target;
        public string Label => label;
        public string Description => description;
    }
}

