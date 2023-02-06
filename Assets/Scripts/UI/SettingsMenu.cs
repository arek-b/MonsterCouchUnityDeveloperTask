using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {

        [SerializeField] private EventSystem eventSystem = null;
        [SerializeField] private MenuManager menuManager = null;

        [SerializeField] private Checkbox checkbox1 = null;
        [SerializeField] private Checkbox checkbox2 = null;
        [SerializeField] private ButtonBack buttonBack = null;

        private void Awake()
        {
            Assert.IsNotNull(eventSystem);
            Assert.IsNotNull(menuManager);
            Assert.IsNotNull(checkbox1);
            Assert.IsNotNull(checkbox2);
            Assert.IsNotNull(buttonBack);
        }

        private void OnEnable()
        {
            eventSystem.SetSelectedGameObject(checkbox1.gameObject);
            buttonBack.PressedBack += Back;
        }

        private void OnDisable()
        {
            buttonBack.PressedBack -= Back;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }
        }

        private void Back()
        {
            menuManager.GoToMainMenu();
        }
    }
}
