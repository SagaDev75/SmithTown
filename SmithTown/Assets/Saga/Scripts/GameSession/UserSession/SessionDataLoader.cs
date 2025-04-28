using System;
using System.Threading.Tasks;
using Saga.GameSession.DataServices;
using Saga.GameSession.DataServices.Serializers;
using Saga.GameSession.Settings;
using Saga.GameSession.Utilities;
using Saga.SystemInitialization;

namespace Saga.GameSession.Session
{
    public class SessionDataLoader : MonoSingleton<SessionDataLoader>
    {
        public const string Path = "/SessionData";

        protected override void OnAwake()
        {
            var serializer = new UnityJsonUtilitySerializer();
            DataService = new JsonServiceAsync(serializer);
        }
        
        private static IDataServiceAsync DataService { get; set; }
        public static SettingsData Data { get; private set; } = new();
        
        public static event Action<DataPhase> OnPhase;
        
        public static async Task Load()
        {
            OnPhase?.Invoke(DataPhase.BeforeLoading);
            
            var data = await DataService.Load<SessionData>(DataUtilities.DataFolder + Path);
            if(data != null) SessionDataController.UpdateData(data);
            
            OnPhase?.Invoke(DataPhase.AfterLoading);
        }
        public static async Task Save()
        {
            OnPhase?.Invoke(DataPhase.BeforeSaving);
            
            //var screen = Instantiate(Singleton.loadingScreen);
            
            await DataService.Save(SessionDataController.CollectData() ,DataUtilities.DataFolder + Path);
            
            //Destroy(screen.gameObject);
            
            OnPhase?.Invoke(DataPhase.AfterSaving);
        }
    }
}
