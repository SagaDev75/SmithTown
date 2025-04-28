using Saga.SystemInitialization;

namespace Saga.ResourceSystem.Recipes
{
    public class RecipePresetStorage : MonoStorage<RecipePresetStorage, RecipePreset>
    {
        public override string FolderName => "RecipePresets";
    }
}

