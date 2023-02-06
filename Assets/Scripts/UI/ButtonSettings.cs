using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonSettings : MonoBehaviour
    {
        private Button button;

        public delegate void OnPressedSettings();
        public event OnPressedSettings PressedSettings;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => PressedSettings.Invoke());
        }
    }
}
