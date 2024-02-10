using Cysharp.Threading.Tasks;

namespace DraasGames.UI.Effects
{
    public interface IEffectReversable : IEffect
    {
        public UniTask Reverse();
    }
}