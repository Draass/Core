using DraasGames.UI.Views;
using Zenject;

namespace DraasGames
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ViewFactory>().FromNew().AsSingle();
        }
    }
}