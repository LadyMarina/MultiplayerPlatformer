using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterAnimator
    {
        private Animator _animator;
        public CharacterAnimator(Animator animator)
        {
            _animator = animator;
		}		   

        public void Jump(bool isJumping)
        {
            _animator.SetBool("isJumping", isJumping);
        }

        public void Falling(bool isFalling)
        {
            _animator.SetBool("isFalling", isFalling);
        }
        
        public void SetXAxis(float axis)
        {
            _animator.SetFloat("XAxis", axis);
        }
    }
}
