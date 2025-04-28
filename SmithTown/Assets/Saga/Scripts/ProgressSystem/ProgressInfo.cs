using System;

namespace Saga.ProgressSystem
{
    [Serializable]
    public struct ProgressInfo
    {
        public int level;
        public int progress;
        public int progressMax;
    }
}

