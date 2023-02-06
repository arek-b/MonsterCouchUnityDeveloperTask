using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] MenuManager menuManager = null;

        // Button references
        [SerializeField] private ButtonPlay buttonPlay = null;
        [SerializeField] private ButtonSettings buttonSettings = null;
        [SerializeField] private ButtonExit buttonExit = null;

        private void Awake()
        {
            Assert.IsNotNull(menuManager);
            Assert.IsNotNull(buttonPlay);
            Assert.IsNotNull(buttonSettings);
            Assert.IsNotNull(buttonExit);
        }

        private void OnEnable()
        {
            buttonPlay.PressedPlay += Play;
            buttonSettings.PressedSettings += Settings;
            buttonExit.PressedExit += Exit;
        }

        private void OnDisable()
        {
            buttonPlay.PressedPlay -= Play;
            buttonSettings.PressedSettings -= Settings;
            buttonExit.PressedExit -= Exit;
        }

        private void Play()
        {
            SceneManager.LoadScene(Config.SceneNames.Game);
        }

        private void Settings()
        {
            menuManager.GoToSettingsMenu();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
