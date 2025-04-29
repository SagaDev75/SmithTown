using Saga.ProgressSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.OrderScreen
{
    public class OrderWidget : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private OrderScreenLogic orderScreen;
        private ProgressOrder _order;
        
        public void SetOrder(ProgressOrder order)
        {
            _order = order;
            image.sprite = order.Icon;
        }

        public void ShowOrderScreen()
        {
            var screen = Instantiate(orderScreen);
            screen.SetOrder(_order);
        }
    }
}