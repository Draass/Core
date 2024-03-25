using DraasGames.UI.Views;
using UnityEngine;
using Zenject;

namespace Examples.ExampleGame.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private IViewRouter _router;
        
        [Inject]
        private void Construct(IViewRouter router)
        {
            _router = router;
        }

        private void Start()
        {
            _router.Show<MainMenu>();
        }
    }
}
