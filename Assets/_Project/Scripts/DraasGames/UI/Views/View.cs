using System;
using UnityEngine;
using UnityEngine.UI;

namespace DraasGames.UI.Views
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    [DisallowMultipleComponent]
    public  class View : MonoBehaviour, IView
    {
        protected Canvas Canvas { get; private set; }
        protected GraphicRaycaster Raycaster { get; private set; }

        public event Action OnViewShow;
        public event Action OnViewHide;

        private void Awake()
        {
            Canvas = GetComponent<Canvas>();
            Raycaster = GetComponent<GraphicRaycaster>();
        }

        public virtual void Show()
        {
            Raycaster.enabled = true;
            Canvas.enabled = true;
            OnViewShow?.Invoke();
        }

        public virtual void Hide()
        {
            Canvas.enabled = false;
            Raycaster.enabled = true;
            OnViewHide?.Invoke();
        }
    }
}