using System;
using Saga.ResourceSystem;

namespace Saga.GameSession.Session
{
    [Serializable]
    public class SessionData
    {
        public int sceneIndex;
        public ResourceSave[] resources;
    }
}