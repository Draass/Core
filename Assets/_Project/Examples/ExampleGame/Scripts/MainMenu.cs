using System;
using DraasGames.UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.ExampleGame.Scripts
{
    public class MainMenu : View
    {
        [SerializeField] private Button _showPopupButton;

        private IViewRouter _router;

        private void Start()
        {
            _showPopupButton.onClick.AddListener(() =>
            {
                Debug.Log("Show Popup");
                _router.ShowAdditive<ExamplePopup>();
            });
        }
    }
}