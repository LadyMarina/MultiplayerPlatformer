using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.Input
{
    public class InputAssignment
    {
        private IGamePad _currentGamePad;
        private Dictionary<Assignements, InputButtons> _inputButtonNames;
        private Dictionary<Assignements, InputAxis> _inputAxisNames;

        public InputAxis HorizontalAxis { get; set; }
        public InputButtons Jump { get; set; }
        
        public enum Assignements
        {
            HorizontalAxis, Jump
        }

        public InputAssignment()
        {
            AssignDefault();
            _inputButtonNames = new Dictionary<Assignements, InputButtons>
            {
                { Assignements.Jump, Jump }
            };
            _inputAxisNames = new Dictionary<Assignements, InputAxis>
            {
                { Assignements.HorizontalAxis, HorizontalAxis }
            };
        }

        public void AssignDefaultGamepad(IGamePad gamePad)
        {
        //    ChangeAssignment(Assignements.HorizontalAxis, 0, gamePad.LeftStickXAxis);
        //    ChangeAssignment(Assignements.Jump, 0, gamePad.AButton);
        }

        public void AssignDefaultKeyboard()
        {
            ChangeAssignment(Assignements.HorizontalAxis, 0, KeyCode.A);
            ChangeAssignment(Assignements.HorizontalAxis, 1, KeyCode.D);
            ChangeAssignment(Assignements.HorizontalAxis, 2, KeyCode.LeftAlt);
            ChangeAssignment(Assignements.HorizontalAxis, 3, KeyCode.RightArrow);
            ChangeAssignment(Assignements.Jump, 0, KeyCode.Space);
            ChangeAssignment(Assignements.Jump, 0, KeyCode.W);
        }

        public void AssignDefault()
        {
            HorizontalAxis = new InputAxis(new []{KeyCode.A, KeyCode.D, KeyCode.LeftArrow, KeyCode.RightArrow});
            Jump = new InputButtons(KeyCode.Space, KeyCode.W);
        }
        
        public void ChangeAssignment(Assignements change, int slot, KeyCode key)
        {
            _inputButtonNames[change].SetKey(slot, key);
        }
        public void ChangeAssignment(Assignements change, int slot, string button)
        {
            if (_inputButtonNames.ContainsKey(change))
            {
                _inputButtonNames[change].SetButton(slot, button);
            }
            else if(_inputAxisNames.ContainsKey(change))
            {
                _inputAxisNames[change].SetButton(slot, button);
            }
            else
            {
                Debug.Log("Input assignement don't exist.");
            }
            
        }
    }
}
