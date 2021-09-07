using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UndefinedBehaviour.Input;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class TestChangeKey : MonoBehaviour
    {

        private InputAssignment _inputAssignment;
        private bool _isAssigning;

        private InputAssignment.Assignements _assingKey;

        private void Awake()
        {
            _inputAssignment = new InputAssignment();

        }

        public void ChangeInput(InputAssignment.Assignements inputToChange)
        {
            _assingKey = inputToChange;
            _isAssigning = true;
        }

        private void Update()
        {
            if (_isAssigning)
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if (UnityEngine.Input.GetKey(key))
                    {
                        _isAssigning = false;
                        _inputAssignment.ChangeAssignment(_assingKey, 0, key);

                    }
                }
            }
        }

    }
}
