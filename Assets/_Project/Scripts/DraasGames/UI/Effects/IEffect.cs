using Cysharp.Threading.Tasks;

namespace DraasGames.UI.Effects
{
    public interface IEffect
    {
        public UniTask Activate();
    }
}