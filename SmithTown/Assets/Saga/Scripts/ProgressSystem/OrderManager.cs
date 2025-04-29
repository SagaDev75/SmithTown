using System;
using System.Collections.Generic;
using System.Linq;
using Saga.GameSession.Session;
using Saga.SystemInitialization;

namespace Saga.ProgressSystem
{
    public class OrderManager : MonoSessionService<OrderManager>
    {
        private readonly List<ProgressOrder> _orders = new();

        public static event Action<IEnumerable<ProgressOrder>> OnReorders;
        public static IEnumerable<ProgressOrder> Orders => Singleton._orders;
        public static void SellOrder(ProgressOrder order)
        {
            Singleton._orders.Remove(order);
            OnReorders?.Invoke(Orders);
        }

        protected override void Start()
        {
            base.Start();
            ProgressManager.OnLevelUp += OnLevelUp;
            OnLevelUp(ProgressManager.CurrentLevelInfo);
        }
        protected override void OnDataCollecting(SessionData data)
        {
            data.orderKeys = _orders.Select(order => order.name).ToArray();
        }
        protected override void OnDataUpdating(SessionData data)
        {
            _orders.Clear();
            _orders.AddRange(data.orderKeys.Select(key => OrderStorage.Storage[key]));
            OnReorders?.Invoke(Orders);
        }
        private void OnLevelUp(ProgressLevelInfo info)
        {
            _orders.Clear();
            _orders.AddRange(info.progressOrders);
            OnReorders?.Invoke(Orders);
        }
    }
}

