using System;
using Saga.GameSession.Session;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.ProgressSystem
{
    public class ProgressManager : MonoSessionService<ProgressManager>
    {
        [SerializeField] private ProgressRewardInfo[] rewards;

        public static int Level { get; private set; } = 0;
        public static int Progress { get; private set; } = 0;
        public static int ProgressMax { get; private set; } = 1;

        public static event Action<ProgressInfo> OnProgress;
        
        public static void GetProgress()
        {
            Progress++;
            if (Progress >= ProgressMax)
            {
                Level++;
                Progress = 0;
                ProgressMax = CalcProgressMax(Level);
                OpenContent(Level);
            }
            
            OnProgress?.Invoke(CollectProgressInfo());
        }
        private static int CalcProgressMax(int level)
        {
            return level + 1;
        }
        private static ProgressInfo CollectProgressInfo()
        {
            return new ProgressInfo()
            {
                level = Level,
                progress = Progress,
                progressMax = ProgressMax,
            };
        }
        private static void OpenContent(int level)
        {
            foreach (var content in Singleton.rewards[level].progressContent)
            {
                content.Unbloked = true;
            }
        }
        private static void RestoreAllProgressContent(int level)
        {
            for (var i = 0; i < level; i++)
            {
                OpenContent(i);
            }
        }

        protected override void OnDataCollecting(SessionData data)
        {
            data.progressInfo = CollectProgressInfo();
        }
        protected override void OnDataUpdating(SessionData data)
        {
            Level = data.progressInfo.level;
            Progress = data.progressInfo.progress;
            RestoreAllProgressContent(ProgressMax);
        }
    }
}

