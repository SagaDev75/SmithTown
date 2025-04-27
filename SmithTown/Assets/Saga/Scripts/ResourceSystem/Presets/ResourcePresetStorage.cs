using Saga.SystemInitialization;

namespace Saga.Items.Presets
{
    public class ResourcePresetStorage : MonoStorage<ResourcePresetStorage, ResourcePreset>
    {
        public override string FolderName => "ResourcePresets";
    }
}