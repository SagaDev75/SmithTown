using Saga.ProgressSystem;
using Saga.ResourceSystem;
using Saga.UIBehaviour.ItemGroupBehaviour;
using Saga.UIBehaviour.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.OrderScreen
{
    public class OrderScreenLogic : ScreenLogic
    {
        [SerializeField] private Image logo;
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private PriceUIGroup group;
        
        private ProgressOrder _order;
        
        public void SetOrder(ProgressOrder order)
        {
            _order = order;
            logo.sprite = order.Icon;
            label.text = order.Label;
            description.text = order.Description;
            group.ShowPrice(order.Target);
        }

        public void SellOrder()
        {
            if(!ResourceManager.TrySpendResources(_order.Target)) return;
            
            OrderManager.SellOrder(_order);
            ProgressManager.GetProgress();
            
            CloseScreen();
        }
    }
}


