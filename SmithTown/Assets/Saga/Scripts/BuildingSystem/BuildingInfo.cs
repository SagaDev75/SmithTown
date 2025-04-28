using Saga.BuildingSystem.Buildings;

namespace Saga.BuildingSystem
{
    public struct BuildingInfo
    {
        public BuildingBranch Branch;
        public int Level;

        public bool IsUnblocked => TryGetPreset(out var preset) && preset.Unbloked;
        public BuildingInfo(BuildingBranch branch, int level = 0)
        {
            this.Branch = branch;
            this.Level = level;
        }

        public bool TryGetPreset(out BuildingPreset preset)
        {
            return Branch.TryGetPreset(Level, out preset);
        }
        public bool TryGetNextPreset(out BuildingPreset preset)
        {
            return Branch.TryGetPreset(Level + 1, out preset);
        }
    }
}

