using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Saga.GameSession.DataServices.Serializers;

namespace Saga.GameSession.DataServices
{
    public class JsonServiceAsync : IDataServiceAsync
    {
        private readonly ISerializer _serializer;
        private const string FileExtension = ".json";

        public JsonServiceAsync(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public async Task Save<T>(T obj, string path, bool overwrite = true)
        {
            var fileLocation = AdaptPath(path);
            
            if (!overwrite && File.Exists(fileLocation))
                throw new IOException($"The file `{fileLocation}` already exist and cannot be overwritten.");
            
            var directory = Path.GetDirectoryName(fileLocation);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            await File.WriteAllTextAsync(fileLocation, _serializer.Serialize(obj));
        }
        public async Task<T> Load<T>(string path)
        {
            var fileLocation = AdaptPath(path);

            if (!File.Exists(fileLocation)) 
                throw new IOException($"The file `{fileLocation}` does not exist and cannot be loaded.");

            var json = await File.ReadAllTextAsync(fileLocation);
            return _serializer.Deserialize<T>(json);
        }
        public void Delete(string path)
        {
            var fileLocation = AdaptPath(path);
            
            if (!File.Exists(fileLocation)) 
                throw new IOException($"The file `{fileLocation}` does not exist and cannot be deleted.");
            
            File.Delete(fileLocation);
        }

        public bool CheckExists(string path)
        {
            return File.Exists(AdaptPath(path));
        }

        public IEnumerable<string> ListSaves(string directoryPath)
        {
            return from path in Directory.EnumerateFiles(directoryPath) 
                where Path.GetExtension(path) == FileExtension 
                select path;
        }
        private static string AdaptPath(string path)
        {
            return string.Concat(path, FileExtension);
        }
    }
}
