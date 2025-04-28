using Saga.SceneService;
using Saga.UIBehaviour.Resource;
using Saga.UIBehaviour.SettingsMenu;
using UnityEngine;

namespace Saga.GameplayLogic
{
    public class GameplayScreenLogic : MonoBehaviour
    {
        [SerializeField] private ResourceScreenLogic resourcesScreenLogic;
        [SerializeField] private SettingsMenuLogic settingsScreenLogic;
        public void ShowResourcesScreen()
        {
            Instantiate(resourcesScreenLogic);
        }
        public void ShowSettingsScreen()
        {
            Instantiate(settingsScreenLogic);
        }
        public void GoToMainMenu()
        {
            SceneController.GoToMainMenu();
        }
    }
}