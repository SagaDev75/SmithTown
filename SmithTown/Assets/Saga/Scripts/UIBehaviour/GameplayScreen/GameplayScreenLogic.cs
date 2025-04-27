using System;
using Saga.GameSession.Session;
using Saga.UIBehaviour.Resource;
using Saga.UIBehaviour.SettingsMenu;
using Saga.UIBehaviour.TutorialScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Saga.GameplayLogic
{
    public class GameplayScreenLogic : MonoBehaviour
    {
        [SerializeField] private ResourceScreenLogic resourcesScreenLogic;
        [SerializeField] private TutorialScreenLogic tutorialScreenLogic;
        [SerializeField] private SettingsMenuLogic settingsScreenLogic;
        public void ShowResourcesScreen()
        {
            Instantiate(resourcesScreenLogic);
        }
        public void ShowSettingsScreen()
        {
            Instantiate(settingsScreenLogic);
        }
        public async void GoToMainMenu()
        {
            await SessionDataLoader.Save();
            SceneManager.LoadScene(0);
        }

        private void Awake()
        {
            Instantiate(tutorialScreenLogic);
        }
    }
}