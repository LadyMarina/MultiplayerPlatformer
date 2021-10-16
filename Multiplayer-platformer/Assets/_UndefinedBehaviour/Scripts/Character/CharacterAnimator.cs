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
            
        public void Jumping()
        {
            _animator.ResetTrigger("OnGround");
            _animator.SetTrigger("isJumping");
        }

        public void Falling()
        {
            _animator.ResetTrigger("isJumping");
            _animator.SetTrigger("isFalling");
        }

        public void OnGround()
        {
            _animator.ResetTrigger("isFalling");
            _animator.ResetTrigger("isJumping");
            _animator.SetTrigger("OnGround");      
        }
        
        public void SetSpeed(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }
    }
}
