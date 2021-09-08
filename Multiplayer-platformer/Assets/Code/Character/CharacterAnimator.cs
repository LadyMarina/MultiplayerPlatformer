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

        public void Jump()
        {
            _animator.SetBool("isJumping",true);
        }
        public void Move(float axis, float speed)
        {

        }
    }
}
