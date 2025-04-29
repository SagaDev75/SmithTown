using Saga.ProgressSystem;
using Saga.SceneService;
using Saga.UIBehaviour.ItemGroupBehaviour;
using Saga.UIBehaviour.Utilities;
using TMPro;
using UnityEngine;

namespace Saga.UIBehaviour.LevelUpScreen
{
    public class LevelUpScreenLogic : ScreenLogic
    {
        [SerializeField] private ItemUIGroup group;

        private ProgressLevelInfo _info;
        
        public void SetInfo(ProgressLevelInfo info)
        {
            _info = info;
            group.ShowItems(info.progressContent);
        }

        public void CloseButton()
        {
            if (_info.nextScene)
            {
                SceneController.GoToNextGameScene();
            }
            else
            {
                CloseScreen();
            }
        }
    }
}

