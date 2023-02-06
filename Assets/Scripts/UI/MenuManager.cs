using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private MainMenu mainMenu = null;
        [SerializeField] private SettingsMenu settingsMenu = null;

        private void Awake()
        {
            Assert.IsNotNull(mainMenu);
            Assert.IsNotNull(settingsMenu);

            GoToMainMenu();
        }

        public void GoToMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
            settingsMenu.gameObject.SetActive(false);
        }

        public void GoToSettingsMenu()
        {
            mainMenu.gameObject.SetActive(false);
            settingsMenu.gameObject.SetActive(true);
        }
    }
}
