using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class TestChangeKey : MonoBehaviour
    {

        private InputAssignment _inputAssignment;
        private bool _isAssigning;

        private string keyToAssing;

        private void Awake()
        {
            _inputAssignment = new InputAssignment();

        }

        public void ChangeInput(string inputToChange)
        {
            keyToAssing = inputToChange;
            _isAssigning = true;
        }

        private void Update()
        {
            if (_isAssigning)
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(key))
                    {
                        _isAssigning = false;
                        _inputAssignment.ChangeAssignment(keyToAssing, 0, key);
                        
                    }
                }
            }
        }

    }
}
