using UnityEngine;

namespace Saga.SystemInitialization
{
    public static class SystemInitializer
    {
        public const string MessagePrefix = "[SystemInitialization] ";
        public const string FolderName = "Systems";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialization()
        {
            var prefabs = Resources.LoadAll<MonoSystem>(FolderName);

            foreach (var prefab in prefabs)
            {
                Object.DontDestroyOnLoad(
                    Object.Instantiate(prefab));
            }
        }
    }
}