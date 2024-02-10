using System;

namespace DraasGames.UI.Views
{
    public interface IView
    {
        public event Action OnViewShow;
        public event Action OnViewHide;

        public void Show();
        public void Hide();
    }
}