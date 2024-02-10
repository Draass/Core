using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace DraasGames.UI.Effects.Concrete
{
    public class PopupAppearEffect : MonoBehaviour, IEffectReversable
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private Vector3 _startScale = new Vector3(.5f, .5f, 1f);
        [SerializeField] private bool _setStartScaleOnStart = false;
        [SerializeField, Range(0f, 2f)] private float _duration = 0.15f;

        private Vector3 _targetScale = Vector3.one;

        private void Awake()
        {
            if (_setStartScaleOnStart)
                _target.localScale = _startScale;
        }

        private void OnDestroy()
        {
            DOTween.Kill(_target);
        }

        public async UniTask Activate()
        {
            _target.DOScale(_targetScale, _duration);
        }

        public async UniTask Reverse()
        {
            _target.DOScale(_startScale, _duration);
        }
    }
}