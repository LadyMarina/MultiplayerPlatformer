using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterAnimator : MonoBehaviour
    {
        public CharacterAnimator(Animator animator)
        {
           
		}		   
        private Animator _characterAnimatorController;
        private void Start()
        {
            _characterAnimatorController = GetComponent<Animator>();
        }
        public void Jump()
        {

        }
        public void Move(float speed)
        {

        }
    }
}
