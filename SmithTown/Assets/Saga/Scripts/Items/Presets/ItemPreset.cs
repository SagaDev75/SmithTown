using UnityEngine;

namespace Saga.Items.Presets
{
    [CreateAssetMenu(menuName = "Saga/Item Preset", fileName = "New Item Preset")]
    public class ItemPreset : ScriptableObject
    {
        [field: SerializeField] public Sprite Icon { get; private set; }

        public static implicit operator string(ItemPreset item)
        {
            return item.name;
        }
    }
}

