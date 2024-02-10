using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace DraasGames.UI.Effects.Concrete
{
    public class MaskAppearAnimation : MonoBehaviour, IEffectReversable
    {
        //TODO просто в анимацию изменения размера
        [SerializeField] private SlideDirection _slideDirection = SlideDirection.UpToDown;
        [SerializeField] private RectTransform _maskRect;

        [SerializeField] private Vector2 _showState;
        [SerializeField] private Vector2 _contentHiddenState;
        
        [SerializeField] private float _duration = .5f;
        
        public async UniTask Activate()
        {
            _maskRect.DOSizeDelta(_contentHiddenState, _duration);
        }

        public async UniTask Reverse()
        {
            _maskRect.DOSizeDelta(_showState, _duration);
        }
    }
}