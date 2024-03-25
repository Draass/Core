using System;
using UnityEditor;

namespace DraasGames.UI.Views
{
    public class ResourcesViewPathRetrieveStrategy : IVewPathRetrieveStrategy
    {
        public string RetrieveViewPath(View view)
        {
            var path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(view);
                
            int index = path.IndexOf("Resources", StringComparison.Ordinal);

            if (index >= 0)
            {
                // Remove everything before "Resources" and ".prefab" at the end
                return path.Substring(index + "Resources".Length + 1).Replace(".prefab", "");
            }

            throw new Exception("View is located outside of Resources folder");
        }
    }
}