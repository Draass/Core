namespace DraasGames.UI.Views
{
    public interface IViewRouter
    {
        public void Show<T>(bool cache = false) where T : View;
        public void ShowAdditive<T>(bool cache = false) where T : View;
        public void Hide<T>() where T : View;
        public void Return();
    }
}