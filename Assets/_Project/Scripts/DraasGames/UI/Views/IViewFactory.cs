using UnityEngine;
using Zenject;

namespace DraasGames.UI.Views
{       
    public interface IViewFactory
    {
        public T Create<T>(string path) where T : View;
    }

    public class ViewFactory : IViewFactory
    {
        private IInstantiator _instantiator;
        
        [Inject]
        public ViewFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create<T>(string path) where T : View
        {
            Debug.Log($"Trying to create prefab of {typeof(T)} by path {path}");
            
            T prefab = Resources.Load<T>(path);
            
            Debug.Log($"Prefab is {prefab}");
            
            return _instantiator.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}