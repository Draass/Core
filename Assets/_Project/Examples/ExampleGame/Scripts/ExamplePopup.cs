using DraasGames.UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.ExampleGame.Scripts
{
    public class ExamplePopup : View
    {
        [SerializeField] private Button _closePopupButton;
        [SerializeField] private Button _returnButton;
        
        private IViewRouter _router;
        
        public void Start()
        {
            _closePopupButton.onClick.AddListener(() =>
            {
                Debug.Log("Close Popup");
                _router.Hide<ExamplePopup>();
            });
            
            _returnButton.onClick.AddListener(() =>
            {
                Debug.Log("Close Popup");
                _router.Return();
            });
        }
    }
}