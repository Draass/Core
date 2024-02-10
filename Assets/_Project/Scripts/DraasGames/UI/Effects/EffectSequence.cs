using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DraasGames.UI.Effects
{
    public class EffectSequence : MonoBehaviour, IEffectSequence
    {
        private List<IEffect> _effectsSequence = new List<IEffect>();

        public void PlaySequence(bool sequentially = true)
        {
            if (sequentially)
            {
                PlaySequential().Forget();
            }
            else
            {
                foreach (var effect in _effectsSequence)
                {
                    effect.Activate().Forget();
                }
            }
        }

        public void CancelSequence()
        {
        }

        private async UniTaskVoid PlaySequential()
        {
            foreach (var effect in _effectsSequence)
            {
                await effect.Activate();
            }
        }

        public void AddEffectToSequence(IEffect effect)
        {
            _effectsSequence.Add(effect);
        }

        public void RemoveEffect(IEffect effect)
        {
        }
    }
}