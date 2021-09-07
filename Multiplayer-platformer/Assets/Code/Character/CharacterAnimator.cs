using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterAnimator : MonoBehaviour
    {
        private Animator _characterAnimatorController;
        private void Start()
        {
            _characterAnimatorController = GetComponent<Animator>();
        }
        public void Jump()
        {

        }
        public void Move(float axis,float speed)
        {

        }
    }
}
