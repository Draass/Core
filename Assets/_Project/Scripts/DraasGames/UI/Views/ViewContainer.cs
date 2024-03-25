using System;
using System.Collections.Generic;
using UnityEngine;

namespace DraasGames.UI.Views
{
    [CreateAssetMenu(menuName = "DraasGames/UI/ViewContainer", fileName = "ViewContainer")]
    public class ViewContainer : ScriptableObject
    {
        [SerializeField] private List<View> _views;
        
        private Dictionary<Type, string> _viewPaths = new();

        private IVewPathRetrieveStrategy _pathRetrieveStrategy;
        
        public string GetViewPath<T>() => _viewPaths[typeof(T)];
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _pathRetrieveStrategy = new ResourcesViewPathRetrieveStrategy();
            
            foreach (var view in _views)
            {
                Type derivedType = view.GetType();
                
                if (_viewPaths.TryGetValue(derivedType, out var viewPath))
                {
                    if(!String.IsNullOrEmpty(viewPath))
                        continue;
                }

                var path = _pathRetrieveStrategy.RetrieveViewPath(view);

                _viewPaths.Add(derivedType, path);
                
                Debug.Log("Added view of " + derivedType + " with path " + path);
            }
        }
#endif
    }
}