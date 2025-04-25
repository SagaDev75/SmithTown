using System.Collections.Generic;
using Saga.SystemInitialization;

namespace Saga.Items.ResourceSystem
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        private readonly Dictionary<string, Resource> _resources = new();

        public static IReadOnlyDictionary<string, Resource> Resources => Singleton._resources;
    }
}

