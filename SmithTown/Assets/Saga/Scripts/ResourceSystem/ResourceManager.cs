using System;
using System.Collections.Generic;
using System.Linq;
using Saga.GameSession.Session;
using Saga.Items.Presets;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.ResourceSystem
{
    public class ResourceManager : MonoSessionService<ResourceManager>
    {
        private readonly Dictionary<string, ResourceData> _resources = new();
        public static IReadOnlyDictionary<string, ResourceData> Resources => Singleton._resources;
        
        public static void DropAllResources()
        {
            Singleton._resources.Clear();
        }
        public static bool ProcessResources(Func<ResourceInfo, ResourceData, bool> processIfExist, Func<ResourceInfo, bool> processIfNotExist, params ResourceInfo[] infos)
        {
            foreach (var info in infos)
            {
                if (Resources.TryGetValue(info, out var resourceData))
                {
                    if (!processIfExist(info, resourceData))
                        return false;
                }
                else
                {
                    if (!processIfNotExist(info))
                        return false;
                }
            }
            return true;
        }
        public static void AddResources(params ResourceInfo[] infos)
        {
            InnerAddResources(infos);
        }
        public static void AddResources(params ResourceSave[] saves)
        {
            InnerAddResources(saves.Select(save => new ResourceInfo(ResourcePresetStorage.Storage[save.ResourceKey], save.ResourceAmount)).ToArray());
        }
        public static bool CheckResources(params ResourceInfo[] infos)
        {
            return ProcessResources(
                (info, data) => data.CheckAmount(info.Amount),
                _ => false,
                infos);
        }
        public static bool TrySpendResources(params ResourceInfo[] infos)
        {
            if (!CheckResources(infos)) return false;
            
            return ProcessResources(
                (info, data) => data.TrySpend(info.Amount),
                _ => true,
                infos);
        }
        public static void SpendResources(params ResourceInfo[] infos)
        {
            ProcessResources(
                (info, data) =>
                {
                    data.Spend(info.Amount);
                    return true;
                },
                _ => true,
                infos);
        }

        protected override void OnDataUpdating(SessionData data)
        {
            DropAllResources();
            AddResources(data.resources);
        }
        protected override void OnDataCollecting(SessionData data)
        {
            data.resources = Resources.Values.Select(resource => new ResourceSave(resource)).ToArray();
        }
        private static void InnerAddResources(params ResourceInfo[] infos)
        {
            ProcessResources(
                (info, data) =>
                {
                    data.Increase(info.Amount);
                    return true;
                },
                info =>
                {
                    var data = new ResourceData(info);
                    Singleton._resources[data.Key] = data;
                    return true;
                }, 
                infos);
        }
    }
}

