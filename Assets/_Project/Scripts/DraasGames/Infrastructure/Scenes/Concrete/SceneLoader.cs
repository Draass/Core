using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DraasGames.Infrastructure.Scenes.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DraasGames.Infrastructure.Scenes.Concrete
{
    public class SceneLoader : ISceneLoader
    {
        public event Action<string> SceneLoadingBegin;
        public event Action<string> SceneLoadingFinished;
        
        public event Action<string> SceneUnloadingBegin;
        public event Action<string> SceneUnloadingFinished;

        public List<Scene> ActiveScenes { get; private set; }
        
        public async UniTask LoadSceneAsync(string scene, bool additive = false)
        {
            SceneLoadingBegin?.Invoke(scene);
            
            var previousScene = SceneManager.GetActiveScene();

            if (additive)
                await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            else 
                await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
            
            ActiveScenes.Add(SceneManager.GetSceneByName(scene));

            if (!additive)
            {
                ActiveScenes.Remove(previousScene);
            }

            SceneLoadingFinished?.Invoke(scene);
        }

        public async UniTask UnloadSceneAsync(string scene)
        {
            SceneLoadingBegin?.Invoke(scene);

            await SceneManager.UnloadSceneAsync(scene);
            
            SceneLoadingFinished?.Invoke(scene);
        }
    }
}