using System;
using Saga.BuildingSystem.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Saga.UIBehaviour.SelectBuildingScreen
{
    public class SelectBuildingWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        
        public event Action<BuildingBranch> OnBuildingSelected;
        
        private BuildingBranch _branch;
        public void SetBuildingPreset(BuildingBranch branch)
        {
            _branch = branch;
            textMesh.text = branch.name;
        }

        public void InvokeSelected()
        {
            OnBuildingSelected?.Invoke(_branch);
        }
    }
}

