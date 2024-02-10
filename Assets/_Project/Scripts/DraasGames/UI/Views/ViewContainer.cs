using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DraasGames.UI.Views
{
    [CreateAssetMenu(menuName = "DraasGames/UI/ViewContainer", fileName = "ViewContainer")]
    public class ViewContainer : ScriptableObject
    {
        [SerializeField] private List<View> _views;
        
        private Dictionary<Type, string> _viewPath = new Dictionary<Type, string>();

#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var view in _views)
            {
                Type derivedType = view.GetType();

                var path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(view);
                
                int index = path.IndexOf("Resources", StringComparison.Ordinal);

                if (index >= 0)
                {
                    // Remove everything before "Resources" and ".prefab" at the end
                    string result = path.Substring(index + "Resources".Length + 1).Replace(".prefab", "");
                    path = result;
                }
                else
                {
                    Debug.LogWarning("Prefab is located outside of Resources folder and probably won't be instantiated in runtime!");
                }

                _viewPath.Add(derivedType, path);
                Debug.Log("Added view of " + derivedType + " with path " + path);
            }
        }
#endif

        public string GetViewPath(View view)
        {
            Type derivedType = view.GetType();
            
            return _viewPath[derivedType];
        }
    }
}