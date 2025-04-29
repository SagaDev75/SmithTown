using System;

namespace Saga.ProgressSystem
{
    [Serializable]
    public struct ProgressLevelInfo
    {
        public bool nextScene;
        public int ordersToUp;
        public ProgressOrder[] progressOrders;
        public ProgressContent[] progressContent;
    }
}

