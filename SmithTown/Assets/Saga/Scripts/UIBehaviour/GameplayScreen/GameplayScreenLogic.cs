using System;
using Saga.ProgressSystem;
using Saga.SceneService;
using Saga.UIBehaviour.LevelUpScreen;
using Saga.UIBehaviour.Resource;
using Saga.UIBehaviour.SettingsMenu;
using UnityEngine;

namespace Saga.GameplayLogic
{
    public class GameplayScreenLogic : MonoBehaviour
    {
        [SerializeField] private ResourceScreenLogic resourcesScreenLogic;
        [SerializeField] private SettingsMenuLogic settingsScreenLogic;
        [SerializeField] private LevelUpScreenLogic levelUpScreenLogic;
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

        private void Awake()
        {
            ProgressManager.OnLevelUp += OnLevelUp;
        }

        private void OnDestroy()
        {
            ProgressManager.OnLevelUp -= OnLevelUp;
        }

        private void OnLevelUp(ProgressLevelInfo obj)
        {
            var screen = Instantiate(levelUpScreenLogic);
            screen.SetInfo(obj);
        }
    }
}