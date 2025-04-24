using System;
using Saga.GameSession.DataServices;
using Saga.SystemInitialization;

namespace Saga.GameSession.Utilities
{
    public class DataLoader<TSelf, TData> : MonoSingleton<TSelf>
        where TSelf : DataLoader<TSelf, TData> 
        where TData : new()
    {
        
        
    }
}