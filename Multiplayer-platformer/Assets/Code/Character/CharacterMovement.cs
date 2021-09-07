
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterMovement
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;

        public CharacterMovement(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
        }
        
        public void Move(float horizontalAxis, float deltaTime)
        {
            _rigidbody2D.velocity = new Vector2(horizontalAxis * deltaTime * _speed, _rigidbody2D.velocity.y);
        }

        public void Jump()
        {
            
        }
    }
}
