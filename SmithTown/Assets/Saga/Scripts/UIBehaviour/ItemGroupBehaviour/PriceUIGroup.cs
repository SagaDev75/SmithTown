using System;
using Saga.GameTickService;
using Saga.ResourceSystem;
using Saga.UIBehaviour.Utilities;
using UnityEngine;

namespace Saga.UIBehaviour.ItemGroupBehaviour
{
    public class PriceUIGroup : MonoBehaviour
    {
        [SerializeField] private ResourceEnoughEvent resourceEnoughEvent;
        [SerializeField] private ItemUIGroup group;

        private ResourceInfo[] _price;
        public void ShowPrice(params ResourceInfo[] infos)
        {
            _price = infos;
            group.ShowItems(infos);
            Check();
        }

        private void Check()
        {
            resourceEnoughEvent.CheckResources(_price);
        }
        private void OnEnable()
        {
            GameTickMachine.AfterTick += Check;
        }
        private void OnDisable()
        {
            GameTickMachine.AfterTick -= Check;
        }
    }
}

