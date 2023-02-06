using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonExit : MonoBehaviour
    {
        private Button button;

        public delegate void OnPressedExit();
        public event OnPressedExit PressedExit;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => PressedExit.Invoke());
        }
    }
}
