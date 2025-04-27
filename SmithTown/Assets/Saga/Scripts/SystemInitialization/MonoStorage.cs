using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Saga.SystemInitialization;
using UnityEngine;

namespace Saga.SystemInitialization
{
    public class MonoStorage<TSelf, TAsset> : MonoSingleton<TSelf>
        where TSelf : MonoStorage<TSelf, TAsset>
        where TAsset : Object
    {
        [SerializeField] private TAsset[] assets;
        
        public virtual string FolderName { get; }

        private readonly Dictionary<string, TAsset> _innerStorage = new();
        public static IReadOnlyDictionary<string, TAsset> Storage => Singleton._innerStorage;
        protected override void OnAwake()
        {
            var presets = Resources.LoadAll<TAsset>(FolderName);

            foreach (var preset in presets)
            {
                if(_innerStorage.TryAdd(preset.name, preset)) continue;
                
                Debug.LogWarning($"Failed to load asset: {preset.name}. Asset Name already exists!");
            }

            assets = Singleton._innerStorage.Values.ToArray();
        }
    }
}

