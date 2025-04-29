using System;
using Saga.BuildingSystem;
using Saga.UIBehaviour.BuildingMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private Image image;
        [SerializeField] private BuyBuildingWidget buyingWidget;
        
        private BuildingInfo _info;
        
        public void SetInfo(BuildingInfo info)
        {
            if (!info.TryGetPreset(out var preset)) return;
            
            _info = info;
            textMesh.text = preset.name;
            image.sprite = preset.Icon;
            buyingWidget.SetInfo(info);
        }
        public void SetBuyingLogic(params Action<BuildingInfo>[] actions)
        {
            foreach (var act in actions)
            {
                buyingWidget.OnBuildingBought += act;
            }
        }
    }
}

