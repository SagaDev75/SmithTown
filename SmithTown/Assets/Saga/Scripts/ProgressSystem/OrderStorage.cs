using Saga.SystemInitialization;

namespace Saga.ProgressSystem
{
    public class OrderStorage : MonoStorage<OrderStorage, ProgressOrder>
    {
        public override string FolderName => "ProgressOrders";
    }
}

