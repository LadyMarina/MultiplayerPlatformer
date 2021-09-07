using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.Input
{
    [Serializable]
    public class InputAssignment
    {
        private IGamePad _currentGamePad;
        private Dictionary<Assignements, InputButtons> _inputButtonNames;
        private Dictionary<Assignements, InputAxis> _inputAxisNames;

        public InputAxis HorizontalAxis { get; set; }
        public InputButtons Jump { get; set; }


        [Serializable]
        public enum Assignements
        {
            Jump, HorizontalAxis
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
            ChangeAssignment(Assignements.Jump, 0, gamePad.AButton);
            ChangeAssignment(Assignements.HorizontalAxis, 0, gamePad.LeftStickXAxis);
        }

        public void AssignDefaultKeyboard()
        {
            ChangeAssignment(Assignements.Jump, 0, KeyCode.Space);
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


    public class InputCharacter
    {
        /*
        private UndefinedBehaviour.MultiplayerPlatformer.InputAssignment _input;
        public float GetVerticalAxis()
        {
            if (_input.Right.GetKeyDown())
            {
                return 1;
            }
            else if (UnityEngine.Input.GetKeyDown(_input.Left.GetKeyDown()))
            {
                return -1;
            }

            return 0;
        }*/
    }
    
    public class InputGod
    {
        
    }
}
