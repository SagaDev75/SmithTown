using System;
using Saga.GameSession.Session;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.ProgressSystem
{
    public class ProgressManager : MonoSessionService<ProgressManager>
    {
        [SerializeField] private ProgressLevelInfo[] levelInfo;
        public static int Level { get; private set; } = 0;
        public static int Progress { get; private set; } = 0;

        public static ProgressLevelInfo CurrentLevelInfo => Singleton.levelInfo[Level];
        public static event Action<ProgressLevelInfo> OnProgress;
        public static event Action<ProgressLevelInfo> OnLevelUp;
        
        public static void GetProgress()
        {
            Progress++;
            
            if (Progress >= CurrentLevelInfo.ordersToUp)
            {
                Level++;
                Progress = 0;
                OpenContent(Level);
                OnLevelUp?.Invoke(CurrentLevelInfo);
            }
            
            OnProgress?.Invoke(CurrentLevelInfo);
        }
        private static void OpenContent(int level)
        {
            foreach (var content in Singleton.levelInfo[level].progressContent)
            {
                content.Unbloked = true;
                Debug.Log("Content opened: " + content.name);
            }
        }
        private static void RestoreAllProgressContent(int level)
        {
            for (var i = 0; i < level; i++)
            {
                OpenContent(i);
            }
        }

        protected override void Start()
        {
            base.Start();
            OpenContent(0);
        }


        protected override void OnDataCollecting(SessionData data)
        {
            data.progressInfo = new ProgressInfo
            {
                level = Level,
                progress = Progress,
            };
        }
        protected override void OnDataUpdating(SessionData data)
        {
            Level = data.progressInfo.level;
            Progress = data.progressInfo.progress;
            RestoreAllProgressContent(Level);
        }
    }
}

