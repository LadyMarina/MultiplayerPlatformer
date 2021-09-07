namespace UndefinedBehaviour.Input
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
        /*
        private UndefinedBehaviour.MultiplayerPlatformer.InputAssignment _input;
        public float GetVerticalAxis()
        {
            if (_input.Right.GetKeyDown())
            {
                return 1;
            }
            else if (UnityEngine.Input.GetKeyDown(_input.Left.GetKeyDown()))
            {
                return -1;
            }

            return 0;
        }*/
    }
}