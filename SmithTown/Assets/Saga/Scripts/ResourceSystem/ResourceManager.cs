using System;
using System.Collections.Generic;
using System.Linq;
using Saga.GameSession.Session;
using Saga.Items.Presets;
using Saga.SystemInitialization;

namespace Saga.ResourceSystem
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        private readonly Dictionary<string, ResourceData> _resources = new();
        public static IReadOnlyDictionary<string, ResourceData> Resources => Singleton._resources;
        
        public static void DropAllResources()
        {
            Singleton._resources.Clear();
        }
        public static void AddResources(params ResourceInfo[] infos)
        {
            foreach (var info in infos)
            {
                InnerAddResource(info);
            }
        }
        public static void AddResources(params ResourceSave[] saves)
        {
            foreach (var save in saves)
            {
                var info = new ResourceInfo(ResourcePresetStorage.Storage[save.ResourceName], save.ResourceAmount);
                InnerAddResource(info);
            }
        }

        private static void OnDataUpdating(SessionData data)
        {
            DropAllResources();
            AddResources(data.resources);
        }
        private static void OnDataCollecting(SessionData data)
        {
            data.resources = Resources.Values.Select(resource => new ResourceSave(resource)).ToArray();
        }
        private static void InnerAddResource(ResourceInfo info)
        {
            if (Resources.TryGetValue(info, out var resourceData))
            {
                resourceData.Increase(info.Amount);
                return;
            }
            
            resourceData = new ResourceData(info);
            Singleton._resources[info] = resourceData;
        }

        private void Start()
        {
            SessionDataController.OnDataCollecting += OnDataCollecting;
            SessionDataController.OnDataUpdating += OnDataUpdating;
        }
    }
}

