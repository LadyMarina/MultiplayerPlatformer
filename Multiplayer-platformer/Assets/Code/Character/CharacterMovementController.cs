using System;
using System.Collections;
using System.Collections.Generic;
using UndefinedBehaviour.Input;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour
    {
        private CharacterInput _characterInput;
        private CharacterMovement _characterMovement;
        private CharacterAnimator _characterAnimator;

        [SerializeField] private float _speed = 5f;
        

        private void Awake()
        {
            _characterInput = new CharacterInput();
            _characterMovement = new CharacterMovement(GetComponent<Rigidbody2D>(), _speed);
        }

        private void FixedUpdate()
        {
            _characterMovement.Move(_characterInput.GetHorizontalAxis(), Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
           // GetComponent<Rigidbody2D>().
        }
    }
}
