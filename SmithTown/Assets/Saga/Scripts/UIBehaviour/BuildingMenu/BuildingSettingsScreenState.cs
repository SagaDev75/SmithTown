using System;
using Saga.GameStateService.States;

namespace Saga.UIBehaviour.BuildingSettingsScreen
{
    public class BuildingSettingsScreenState : MonoGameStateBase
    {
        private void Awake()
        {
            RegisterSelf();
        }

        private void OnDestroy()
        {
            UnregisterSelf();
        }
    }
}

