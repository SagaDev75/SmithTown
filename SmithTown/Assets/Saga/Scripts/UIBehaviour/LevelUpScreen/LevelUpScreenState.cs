using System;
using Saga.GameStateService.States;

namespace Saga.UIBehaviour.LevelUpScreen
{
    public class LevelUpScreenState : MonoGameStateBase
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

