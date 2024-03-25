using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DraasGames.UI.Views
{
    public class ViewRouter : IViewRouter, IDisposable
    {
        private Dictionary<Type, View> _cachedViews = new Dictionary<Type, View>();
        private Dictionary<Type, View> _activeViews = new Dictionary<Type, View>();

        public List<View> ActiveViews = new List<View>();
        public Stack<View> ViewStack = new Stack<View>();

        private IViewFactory _viewFactory;
        private ViewContainer _viewContainer;

        [Inject]
        public ViewRouter(IViewFactory viewFactory, ViewContainer viewContainer)
        {
            _viewFactory = viewFactory;
            _viewContainer = viewContainer;
        }
        
        public void Show<T>(bool cache = false) where T : View
        {
            if (_cachedViews.TryGetValue(typeof(T), out var cachedView))
            {
                cachedView.Show();
                return;
            }
            
            //TODO disable current active view
            
            var targetView = _viewFactory.Create<T>(_viewContainer.GetViewPath<T>());
            targetView.Show();
            
            ViewStack.Push(targetView);
            ActiveViews.Add(targetView);
            
            if (cache)
            {
                _cachedViews.Add(typeof(T), targetView);
            }
        }

        /// <summary>
        /// Show view without disabling previous one
        /// </summary>
        /// <param name="view"></param>
        /// <param name="cache"></param>
        public void ShowAdditive<T>(bool cache = false) where T : View
        {
            throw new System.NotImplementedException();
        }

        public void Hide<T>() where T : View
        {
            _activeViews[typeof(T)].Hide();

            if (!_cachedViews.ContainsKey(typeof(T)))
                return;
            
            GameObject.Destroy(_activeViews[typeof(T)]);
            _activeViews.Remove(typeof(T));
        }

        public void Return()
        {
            // выташить последний из стека
        }

        public void Dispose()
        {
            foreach (var view in _cachedViews.Values)
            {
                GameObject.Destroy(view);
            }
            
            _cachedViews.Clear();
            _activeViews.Clear();
            ViewStack.Clear();
        }
    }
}