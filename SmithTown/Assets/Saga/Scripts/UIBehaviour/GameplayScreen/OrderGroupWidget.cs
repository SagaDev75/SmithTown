using System.Collections.Generic;
using Saga.ProgressSystem;
using UnityEngine;

namespace Saga.UIBehaviour.OrderScreen
{
    public class OrderGroupWidget : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private OrderWidget orderWidgetPrefab;

        private void ReshowOrders(IEnumerable<ProgressOrder> orders)
        {
            Clear();
            
            foreach (var item in orders)
            {
                CreateWidget(item);
            }
        }
        private void Clear()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void Awake()
        {
            OrderManager.OnReorders += ReshowOrders;
            ReshowOrders(OrderManager.Orders);
        }
        private void OnDestroy()
        {
            OrderManager.OnReorders -= ReshowOrders;
        }

        private OrderWidget CreateWidget(ProgressOrder item)
        {
            var widget = Instantiate(orderWidgetPrefab, container);
            widget.SetOrder(item);
            return widget;
        }
    }
}

