using UnityEngine;

namespace UndefinedBehaviour
{
    public class InputButtons
    {
        private const int MAX_SLOTS = 2;

        private KeyCode[] _keys = new KeyCode[MAX_SLOTS];
        private string[] _buttons = new string[MAX_SLOTS];
        
        public InputButtons(KeyCode key1, KeyCode key2 = KeyCode.None)
        {
            _keys[0] = key1;
            _keys[1] = key2;
        }
        public InputButtons(KeyCode key1, KeyCode key2, string button1, string button2)
        {
            _keys[0] = key1;
            _keys[1] = key2;
            _buttons[0] = button1;
            _buttons[1] = button2;
        }

        public bool GetKeyDown()
        {
            foreach (var key in _keys)
            {
                if (Input.GetKeyDown(key))
                {
                    return true;
                }
            }
            
            foreach (var button in _buttons)
            {
                if (Input.GetButtonDown(button))
                {
                    return true;
                }
            }

            return false;
        }

       
    }
}