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

        public bool GetAction()
        {
            foreach (var key in _keys)
            {
                if (UnityEngine.Input.GetKey(key))
                {
                    return true;
                }
            }
            
            /*foreach (var button in _buttons)
            {
                if (UnityEngine.Input.GetButton(button))
                {
                    return true;
                }
            }*/

            return false;
        }
        public bool GetActionDown()
        {
            foreach (var key in _keys)
            {
                if (UnityEngine.Input.GetKeyDown(key))
                {
                    return true;
                }
            }
            
            /*foreach (var button in _buttons)
            {
                if (button == "")
                    continue;
                if (UnityEngine.Input.GetButtonDown(button))
                {
                    return true;
                }
            }*/

            return false;
        }
        public bool GetActionUp()
        {
            foreach (var key in _keys)
            {
                if (UnityEngine.Input.GetKeyUp(key))
                {
                    return true;
                }
            }
            
      /*      foreach (var button in _buttons)
            {
                if (button == "")
                    continue;
                if (UnityEngine.Input.GetButtonUp(button))
                {
                    return true;
                }
            }
/*/
            return false;
        }

        public KeyCode GetKey(int slot)
        {
            return _keys[slot];
        }

        public void SetKey(int slot, KeyCode key)
        {
            _keys[slot] = key;
        }
        
        public string GetButton(int slot)
        {
            return _buttons[slot];
        }

        public void SetButton(int slot, string button)
        {
            _buttons[slot] = button;
        }
    }
}