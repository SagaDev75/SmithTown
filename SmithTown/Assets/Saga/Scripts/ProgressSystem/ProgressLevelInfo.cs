using System;

namespace Saga.ProgressSystem
{
    [Serializable]
    public struct ProgressRewardInfo
    {
        public bool nextScene;
        public ProgressContent[] progressContent;
    }
}

