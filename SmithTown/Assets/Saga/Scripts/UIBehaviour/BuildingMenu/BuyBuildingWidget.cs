using System;
using Saga.BuildingSystem;
using Saga.ResourceSystem;
using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.UIBehaviour.BuildingMenu
{
    public class BuyBuildingWidget : MonoBehaviour
    {
        [SerializeField] private PriceUIGroup priceUIGroup;
        
        private BuildingInfo _info;
        
        public event Action<BuildingInfo> OnBuildingBought;
        
        public void SetInfo(BuildingInfo info)
        {
            if (info.TryGetPreset(out var preset))
            {
                _info = info;
                priceUIGroup.ShowPrice(preset.Price);
            }
        }
        public void InvokeBuying()
        {
            if(_info.TryGetPreset(out var preset) 
               && ResourceManager.TrySpendResources(preset.Price)) OnBuildingBought?.Invoke(_info);
        }
    }
}