using UnityEngine;

namespace UndefinedBehaviour.Input
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
                if (UnityEngine.Input.GetKeyDown(key))
                {
                    return true;
                }
            }
            
            foreach (var button in _buttons)
            {
                if (UnityEngine.Input.GetButtonDown(button))
                {
                    return true;
                }
            }

            return false;
        }
    }
    
    public class InputAxis
    {
        private const int MAX_SLOTS = 2;
        
        private KeyCode[] _keys = new KeyCode[MAX_SLOTS * 2];
        private string[] _buttons = new string[MAX_SLOTS];
        
        /// <summary>
        /// Limited to MAX_SLOTS * 2 value.
        /// </summary>
        /// <param name="keys"></param>
        public InputAxis(KeyCode[] keys)
        {
            for (int i = 0; i < MAX_SLOTS * 2; i++)
            {
                _keys[i] = keys[i];
            }
        }

        /// <summary>
        /// Limited to MAX_SLOTS * 2 value for keys, and MAX_SLOTS for buttons
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="buttons"></param>
        public InputAxis(KeyCode[] keys, string[] buttons)
        {
            for (int i = 0; i < MAX_SLOTS * 2; i++)
            {
                _keys[i] = keys[i];
            }
            
            for (int i = 0; i < MAX_SLOTS; i++)
            {
                _buttons[i] = buttons[i];
            }
        }
    }
}