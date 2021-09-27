using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterMovement
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        private float _jumpForce;

        public CharacterMovement(Rigidbody2D rigidbody2D, float speed, float jumpForce)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
            _jumpForce = jumpForce;
        }
        
        public void Move(float horizontalAxis, float deltaTime)
        {
            _rigidbody2D.velocity = new Vector2(horizontalAxis * deltaTime * _speed, _rigidbody2D.velocity.y);
        }

        public void Jump(ref bool isOnGround, bool jumpActionDown)
        {
            if(!isOnGround)
                return;

            if (!jumpActionDown)
                return;
            
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            isOnGround = false;
        }
    }
}
