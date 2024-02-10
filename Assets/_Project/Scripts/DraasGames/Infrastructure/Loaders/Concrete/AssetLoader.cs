using Cysharp.Threading.Tasks;
using DraasGames.Infrastructure.Loaders.Abstract;
using UnityEngine;

namespace DraasGames.Infrastructure.Loaders.Concrete
{
    public class AssetLoader : IPrefabLoader
    {
        public async UniTask<GameObject> LoadAssetAsync(string path)
        {
            var asset = await Resources.LoadAsync<GameObject>(path);

            return (GameObject) asset;
        }
    }
}