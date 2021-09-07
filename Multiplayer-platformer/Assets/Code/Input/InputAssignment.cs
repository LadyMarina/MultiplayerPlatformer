using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.Input
{
    public class InputAssignment
    {
        public InputAxis HorizontalAxis { get; set; }
        public InputButtons Jump { get; set; }
        private Dictionary<string, InputButtons> _inputButtonNames;
        
        public void AssignDefaultGamepad(IGamePad gamePad)
        {
           ChangeAssignment(HorizontalAxis, 1, gamePad.LeftStickXAxis);
        }

        public void AssignDefaultKeyboard()
        {
            ChangeAssignment(HorizontalAxis, 1, KeyCode.A, KeyCode.D);
            ChangeAssignment(HorizontalAxis, 1, KeyCode.LeftArrow, KeyCode.RightArrow);
            ChangeAssignment(Jump, 1, KeyCode.Space);
        }

        public void AssignDefault()
        {
            HorizontalAxis = new InputAxis(new []{KeyCode.A, KeyCode.D, KeyCode.LeftArrow, KeyCode.RightArrow});
            Jump = new InputButtons(KeyCode.Space, KeyCode.W);
        }
        
        public void ChangeAssignment(string change, int slot, KeyCode key)
        {
            
        }
        public void ChangeAssignment(string change, int slot, string button)
        {
            
        }
        
        public InputAssignment()
        {
            _inputButtonNames = new Dictionary<string, InputButtons>();
            _inputButtonNames.Add("Jump", Jump);
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
