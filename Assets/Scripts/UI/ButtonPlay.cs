using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonPlay : MonoBehaviour
    {
        private Button button;

        public delegate void OnPressedPlay();
        public event OnPressedPlay PressedPlay;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => PressedPlay.Invoke());
        }
    }
}
