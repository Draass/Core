using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace DraasGames.UI.Effects.Concrete
{
    public class FadeAnimation : MonoBehaviour, IEffectReversable
    {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private float _duration;

        [SerializeField, Range(0, 1)] private float _initialAlpha = 1f;
        [SerializeField, Range(0, 1)] private float _targetAlpha = 0f;
        
        public async UniTask Activate()
        {
            Fade();
        }
        
        public async UniTask Reverse()
        {
            UnFade();
        }
        
        private void Fade()
        {
            _group.DOFade(_targetAlpha, _duration);
        }

        private void UnFade()
        {
            _group.DOFade(_initialAlpha, _duration);
        }
    }
}