using UnityEngine;

namespace Saga.GameSession.DataServices.Serializers
{
    public class UnityJsonUtilitySerializer : ISerializer
    {
        private readonly bool _prettyPrint;
        
        public UnityJsonUtilitySerializer(bool prettyPrint = true)
        {
            _prettyPrint = prettyPrint;
        }

        public string Serialize<T>(T obj)
        {
            return JsonUtility.ToJson(obj, _prettyPrint);
        }
        public T Deserialize<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}


