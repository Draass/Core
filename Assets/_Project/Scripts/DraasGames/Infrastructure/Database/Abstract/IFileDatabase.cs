namespace DraasGames.Infrastructure.Database.Abstract
{
    public interface IFileDatabase
    {
        /// <summary>
        /// Save file of given type at path
        /// </summary>
        /// <param name="path">Absolute path to file</param>
        public void Save<T>(T file, string path);
       
        /// <summary>
        /// Load file of given type from path
        /// </summary>
        /// <param name="path">Absolute path to file</param>
        public T Load<T>(string path);
        
        /// <summary>
        /// Remove file from path
        /// </summary>
        /// <param name="path">Absolute path to file</param>
        public void Remove(string path);
    }
}