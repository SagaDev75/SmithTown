using UnityEngine;

namespace Saga.UIBehaviour.BuildingSettingsScreen
{
    public class BuildingSettingsScreenLogic : MonoBehaviour
    {
        public void CloseWindow()
        {
            Destroy(gameObject);
        }
    }
}