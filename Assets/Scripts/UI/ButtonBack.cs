using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonBack : MonoBehaviour
    {
        private Button button;

        public delegate void OnPressedBack();
        public event OnPressedBack PressedBack;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => PressedBack.Invoke());
        }
    }
}
