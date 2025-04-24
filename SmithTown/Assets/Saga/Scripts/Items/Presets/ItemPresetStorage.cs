using Saga.SystemInitialization;

namespace Saga.Items.Presets
{
    public class ItemPresetStorage : MonoStorage<ItemPresetStorage, ItemPreset>
    {
        public override string FolderName => "ItemPresets";
    }
}