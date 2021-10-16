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
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        
        [SerializeField, Range(-1.0f, 0.0f)] private float _detectGroundRange = -0.9f;
        [Space]
        [SerializeField] private UnityEvent Grounded;
        [SerializeField] private UnityEvent Jumping;

        private float _YSpeed;
        private Rigidbody2D _rigidbody2D;
        private CharacterInput _characterInput;
        private CharacterMovement _characterMovement;
        private CharacterAnimator _characterAnimator;
        
        private bool _isOnGround = false;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _characterInput = new CharacterInput();
            _characterMovement = new CharacterMovement(_rigidbody2D, _speed, _jumpForce);
            Animator myAnimator = GetComponent<Animator>();
            _characterAnimator = new CharacterAnimator(myAnimator);

            Grounded.AddListener(OnGrounded);
            Grounded.AddListener(_characterAnimator.OnGround);
            Jumping.AddListener(_characterAnimator.Jumping);
        }

        private void Update()
        {
            _characterMovement.Jump(ref _isOnGround, _characterInput.GetJumpActionDown());
            _characterAnimator.SetSpeed(Mathf.Clamp(_rigidbody2D.velocity.x, -1, 1));


            _YSpeed = Mathf.Clamp(_rigidbody2D.velocity.y, -1, 1);
            if (!_isOnGround && _characterInput.GetJumpActionDown())
            {
                if (_YSpeed == 1)
                {
                    Jumping.Invoke();
                }
            }
            if (!_isOnGround)
            {
                if (_YSpeed == -1)
                {
                    _characterAnimator.Falling();
                }

            }

            if (_characterInput.GetHorizontalAxis() != 0)
            {
                if (_characterInput.GetHorizontalAxis() == -1)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else if (_characterInput.GetHorizontalAxis() == 1)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
               
            }
           

           
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
            if (_isOnGround)
            {
                return;
            }
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            _rigidbody2D.GetContacts(contacts);
            
            foreach (var contact in contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.down) < _detectGroundRange)
                {
                    Grounded.Invoke();
                }
            }
        }
    }
}
