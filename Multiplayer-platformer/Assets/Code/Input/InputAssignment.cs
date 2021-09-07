using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour
{
    public class InputAssignment
    {
        public InputButtons Right { get; set; }
        public InputButtons Left { get; set; }
        public InputButtons Jump { get; set; }
        
        public void AssignDefaultGamepad(IGamePad gamePad)
        {
           
        }

        public void AssignDefaultKeyboard()
        {
                
        }

        public void AssignDefault()
        {
            
        }
        
        public void ChangeAssignment(InputButtons change, int slot, KeyCode key)
        {
            
        }
        public void ChangeAssignment(InputButtons change, int slot, string button)
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
