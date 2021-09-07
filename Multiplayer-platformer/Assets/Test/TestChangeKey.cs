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
        private InputAssignment.Assignements _assingKey;

        private void Awake()
        {
            _inputAssignment = new InputAssignment();
        }

        public void ChangeInput(InputAssignment.Assignements inputToChange)
        {
            _assingKey = inputToChange;
            StopCoroutine(Assign());
            StartCoroutine(Assign());
        }

        IEnumerator Assign()
        {
            bool isAssigning = true;
            while (isAssigning)
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if (UnityEngine.Input.GetKey(key))
                    {
                        isAssigning = false;
                        _inputAssignment.ChangeAssignment(_assingKey, 0, key);
                    }
                }
                yield return null;
            }
            
        }

    }
}
