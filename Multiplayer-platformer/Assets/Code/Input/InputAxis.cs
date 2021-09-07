using UnityEngine;

namespace UndefinedBehaviour.Input
{
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

        /// <summary>
        /// -1 0 1
        /// </summary>
        /// <returns></returns>
        public float GetAxisRaw()
        {
            for (int i = 0; i < _keys.Length; i = i+2)
            {
                if (UnityEngine.Input.GetKey(_keys[i]))
                {
                    return -1.0f;
                }
            }
            for (int i = 1; i < _keys.Length; i = i+2)
            {
                if (UnityEngine.Input.GetKey(_keys[i]))
                {
                    return 1.0f;
                }
            }

            return 0;
        }
        
        public KeyCode GetKey(int slot)
        {
            return _keys[slot];
        }

        public void SetKey(int slot, KeyCode key)
        {
            _keys[slot] = key;
        }
        
        public string Button(int slot)
        {
            return _buttons[slot];
        }

        public void SetButton(int slot, string button)
        {
            _buttons[slot] = button;
        }
    }
}