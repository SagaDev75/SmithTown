namespace Saga.ResourceSystem.Recipes
{
    public struct RecipeInfo
    {
        public RecipePreset preset;
        public int step;

        public float Percentage
        {
            get
            {
                if(preset ==null) return 0;
                
                return (float)step / preset.Duration;
            }
        }   
    }
}

