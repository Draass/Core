using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace DraasGames.Infrastructure.Scenes.Abstract
{
    public interface ISceneLoader
    {
        public event Action<string> SceneLoadingBegin;
        public event Action<string> SceneLoadingFinished;

        public event Action<string> SceneUnloadingBegin;
        public event Action<string> SceneUnloadingFinished;
        
        public List<Scene> ActiveScenes { get; }
        
        public UniTask LoadSceneAsync(string scene, bool additive = false);
        public UniTask UnloadSceneAsync(string scene);
    }
}