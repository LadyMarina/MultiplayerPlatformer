using System;
using System.Collections;
using System.Collections.Generic;
using UndefinedBehaviour.Input;
using UnityEngine;
using UnityEngine.Events;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour
    {
        private CharacterInput _characterInput;
        private CharacterMovement _characterMovement;
        private CharacterAnimator _characterAnimator;

        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 5f;

        private Rigidbody2D _rigidbody2D;

        [SerializeField] private UnityEvent Grounded;

        private bool _isOnGround = false;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _characterInput = new CharacterInput();
            _characterMovement = new CharacterMovement(_rigidbody2D, _speed, _jumpForce);
            _characterAnimator = new CharacterAnimator(GetComponent<Animator>());
            
            Grounded.AddListener(OnGrounded);
        }

        private void Update()
        {
            _characterMovement.Jump(ref _isOnGround, _characterInput.GetJumpActionDown());
        }

        private void FixedUpdate()
        {
            _characterMovement.Move(_characterInput.GetHorizontalAxis(), Time.deltaTime);
        }

        private void OnGrounded()
        {
            _isOnGround = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DetectGroundCollision();
        }

        private void DetectGroundCollision()
        {
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            _rigidbody2D.GetContacts(contacts);

            foreach (var contact in contacts)
            {
                Debug.Log(contact.normal + " " + Vector2.Dot(contact.normal, Vector2.down));
                if (Vector2.Dot(contact.normal, Vector2.down) < -0.9f)
                {
                    Grounded.Invoke();
                }
            }
        }
    }
}
