using UnityEngine;

namespace Saga.Items.Presets
{
    [CreateAssetMenu(menuName = "Saga/ResourcePreset", fileName = "New Resource Preset")]
    public class ResourcePreset : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }

        public static implicit operator string(ResourcePreset resource)
        {
            return resource.name;
        }
    }
}

