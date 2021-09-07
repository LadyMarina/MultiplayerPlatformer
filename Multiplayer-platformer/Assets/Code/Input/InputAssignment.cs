using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.Input
{
    [Serializable]
    public class InputAssignment
    {
        public InputAxis HorizontalAxis { get; set; }
        public InputButtons Jump { get; set; }

        private Dictionary<Assignements, InputButtons> _inputButtonNames;

        [Serializable]
        public enum Assignements
        {
            Jump, Attack
        }

        public InputAssignment()
        {
            _inputButtonNames = new Dictionary<Assignements, InputButtons>();
            AssignDefault();
            _inputButtonNames.Add(Assignements.Jump, Jump);
            
        }

        public void AssignDefaultGamepad(IGamePad gamePad)
        {
          // ChangeAssignment(HorizontalAxis, 1, gamePad.LeftStickXAxis);
        }

        public void AssignDefaultKeyboard()
        {
            //ChangeAssignment(HorizontalAxis, 1, KeyCode.A, KeyCode.D);
            //ChangeAssignment(HorizontalAxis, 1, KeyCode.LeftArrow, KeyCode.RightArrow);
            ChangeAssignment(Assignements.Jump, 1, KeyCode.Space);
        }

        public void AssignDefault()
        {
            HorizontalAxis = new InputAxis(new []{KeyCode.A, KeyCode.D, KeyCode.LeftArrow, KeyCode.RightArrow});
            Jump = new InputButtons(KeyCode.Space, KeyCode.W);
        }
        
        public void ChangeAssignment(Assignements change, int slot, KeyCode key)
        {
            Debug.Log(Jump);
            Debug.Log(_inputButtonNames[change]);
            _inputButtonNames[change].SetKey(slot, key);
        }
        public void ChangeAssignment(Assignements change, int slot, string button)
        {
            
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
