using Saga.SystemInitialization;

namespace Saga.BuildingSystem.Buildings
{
    public class BuildingBranchStorage : MonoStorage<BuildingBranchStorage, BuildingBranch>
    {
        public override string FolderName => "BuildingBranches";
    }
}