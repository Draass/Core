using System.IO;
using DraasGames.Infrastructure.Database.Abstract;
using UnityEngine;

namespace DraasGames.Infrastructure.Database.Concrete
{
    /// <summary>
    /// Most simple and generic json database writer. Do not use if you are going to keep something
    /// more complex than a bunch of primitive types, instead write a NewtonSoft implementation
    /// </summary>
    public class JsonUtilityDatabase : IFileDatabase
    {
        public void Save<T>(T file, string path)
        {
            var fileJson = JsonUtility.ToJson(file);
            File.WriteAllText(path, fileJson);
        }

        public T Load<T>(string path)
        {
            var fileJson = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(fileJson);
        }

        public void Remove(string path)
        {
            File.Delete(path);
        }
    }
}