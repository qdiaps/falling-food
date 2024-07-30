using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Infrastructure.Service.Storage
{
    public class JsonToFileStorageService : IStorageService
    {
        public void Save(string key, object data)
        {
            string path = CreatePath(key);
            string json = JsonConvert.SerializeObject(data);
            using var fileStream = new StreamWriter(path);
            fileStream.Write(json);
        }

        public T Load<T>(string key)
        {
            string path = CreatePath(key);
            if (File.Exists(path) == false)
                return default;
            using var fileStream = new StreamReader(path);
            string json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }

        private string CreatePath(string key) =>
            Path.Combine(Application.persistentDataPath, key);
    }
}