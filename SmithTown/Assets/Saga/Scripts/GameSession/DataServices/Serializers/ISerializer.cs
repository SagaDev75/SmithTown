namespace Saga.GameSession.DataServices.Serializers
{
    public interface ISerializer
    {
        public string Serialize<T>(T obj);
        public T Deserialize<T>(string file);
    }
}