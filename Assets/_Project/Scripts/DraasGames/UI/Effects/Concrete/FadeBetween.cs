using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace DraasGames.UI.Effects.Concrete
{
    public class FadeBetween : MonoBehaviour, IEffect
    {
        /// <summary>
        /// Group to appear
        /// </summary>
        [SerializeField] private CanvasGroup _fadeInGroup;
        
        /// <summary>
        /// Group to disappear
        /// </summary>
        [SerializeField] private CanvasGroup _fadeOutGroup;

        [SerializeField] private float _duration = 1f;
        
        public async UniTask Activate()
        {
            _fadeInGroup.DOFade(1, _duration);
            _fadeOutGroup.DOFade(0, _duration);
        }

        public void SetFadePair(CanvasGroup fadeInGroup, CanvasGroup fadeOutGroup)
        {
            _fadeInGroup = fadeInGroup;
            _fadeOutGroup = fadeOutGroup;
        }
    }
}