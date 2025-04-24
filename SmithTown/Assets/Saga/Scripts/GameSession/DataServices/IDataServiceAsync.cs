using System.Threading.Tasks;

namespace Saga.GameSession.DataServices
{
    public interface IDataServiceAsync : IDataService
    {
        new Task Save<T>(T obj, string key, bool overwrite = true);
        new Task<T> Load<T>(string key);

        void IDataService.Save<T>(T obj, string key, bool overwrite)
        {
            Save(obj, key, overwrite);
        }
        T IDataService.Load<T>(string key)
        {
            return Load<T>(key).Result;
        }
    }
}
