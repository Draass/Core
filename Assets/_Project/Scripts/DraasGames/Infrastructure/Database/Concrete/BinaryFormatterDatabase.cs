using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DraasGames.Infrastructure.Database.Abstract;
using UnityEngine;

namespace DraasGames.Infrastructure.Database.Concrete
{
    /// <summary>
    /// Database for writing binary files. Using is not recommended, because BinaryFormatter is outdated
    /// </summary>
    public class BinaryFormatterDatabase : IFileDatabase
    {
        private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();
        
        public void Save<T>(T file, string path)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.Create);
                
                BinaryFormatter.Serialize(fileStream, file);
            }
            catch(Exception e)
            {
                Debug.LogError(e.ToString());
            };
        }

        public T Load<T>(string path)
        {
            var output = default(T);
            
            if (!File.Exists(path))
            {
                Debug.LogError("Path dont exist");
                return output;
            }
            
            try
            {
                using var fileStream = new FileStream(path, FileMode.Open);
                fileStream.Position = 0;
                
                return (T)BinaryFormatter.Deserialize(fileStream);
            }
            catch(Exception e)
            {
                Debug.LogError(e.ToString());
            }

            return output;
        }

        public void Remove(string path)
        {
            File.Delete(path);
        }
    }
}