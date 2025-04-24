using System.Collections.Generic;

namespace Saga.GameSession.DataServices
{
    public interface IDataService
    {
        void Save<T>(T obj, string key, bool overwrite = true);
        T Load<T>(string key);
        void Delete(string key);
        bool CheckExists(string key);
        IEnumerable<string> ListSaves(string directoryKey);
    }
}
