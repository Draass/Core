using DraasGames.UI.Views;
using UnityEngine;
using Zenject;

namespace Examples.ExampleGame.Scripts
{
    public class ExampleInstaller : MonoInstaller
    {
        [SerializeField] private ViewContainer _viewContainer;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ViewFactory>().FromNew().AsSingle();
            Container.BindInterfacesTo<ViewRouter>().FromNew().AsSingle();
            
            Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
        }
    }
}
