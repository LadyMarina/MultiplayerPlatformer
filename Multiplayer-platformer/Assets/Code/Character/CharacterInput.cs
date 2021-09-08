using UndefinedBehaviour.Input;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterInput
    {
        private InputAssignment _inputAssignment;

        public CharacterInput()
        {
            _inputAssignment = new InputAssignment();
        }

        public float GetHorizontalAxis()
        {
            return _inputAssignment.HorizontalAxis.GetAxisRaw();
        }

        public bool GetJumpActionDown()
        {
            return _inputAssignment.Jump.GetActionDown();
        }
    }
}