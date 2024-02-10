using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace DraasGames.UI.Effects.Concrete
{
    public class ElementSlideEffect : MonoBehaviour, IEffectReversable
    {
        [SerializeField] private RectTransform _target;
        [SerializeField] private SlideDirection _slideDirection = SlideDirection.RightToLeft;
        [SerializeField, Range(0f, 2f)] private float _duration = 1f;

        [Tooltip("How far will element slide? By default it sides on full element axis size")]
        [SerializeField] private float _slideFactor = 1f;
        //TODO заменить полотно стратегиями

        private float posXInitial;
        
        private void Start()
        {
            //posXInitial = _target.anchoredPosition.x;
            posXInitial = _target.position.x;
        }
        
        public async UniTask Activate()
        {
            //BUG If scene is additively loaded, pos initial is 0
            if(posXInitial == 0)
                posXInitial = _target.position.x;
            
            switch (_slideDirection)
            {
                case SlideDirection.LeftToRight:
                    throw new NotImplementedException();
                    break;
                case SlideDirection.RightToLeft:
                    await _target.DOMoveX(posXInitial - _target.sizeDelta.x * _slideFactor, _duration).AsyncWaitForCompletion();
                    break;
                case SlideDirection.UpToDown:
                    throw new NotImplementedException();
                    break;
                case SlideDirection.DownToUp:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async UniTask Reverse()
        {
            switch (_slideDirection)
            {
                case SlideDirection.LeftToRight:
                    throw new NotImplementedException();
                    break;
                case SlideDirection.RightToLeft:
                    _target.DOMoveX(posXInitial, _duration);
                    break;
                case SlideDirection.UpToDown:
                    throw new NotImplementedException();
                    break;
                case SlideDirection.DownToUp:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}