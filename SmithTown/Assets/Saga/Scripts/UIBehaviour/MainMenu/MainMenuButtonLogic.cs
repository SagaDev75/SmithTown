using Saga.UIBehaviour.SettingsMenu;
using UnityEngine;

namespace Saga.UIBehaviour.MainMenu
{
    public class MainMenuButtonLogic : MonoBehaviour
    {
        [SerializeField] private SettingsMenuState settingsMenu;

        public void OpenSettingsMenu()
        {
            Instantiate(settingsMenu);
        }
    }
}

