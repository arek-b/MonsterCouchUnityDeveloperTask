using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] MenuManager menuManager = null;

        [SerializeField] ButtonBack buttonBack = null;

        private void Awake()
        {
            Assert.IsNotNull(menuManager);
            Assert.IsNotNull(buttonBack);
        }

        private void OnEnable()
        {
            buttonBack.PressedBack += Back;
        }

        private void OnDisable()
        {
            buttonBack.PressedBack -= Back;
        }

        private void Back()
        {
            menuManager.GoToMainMenu();
        }
    }
}
