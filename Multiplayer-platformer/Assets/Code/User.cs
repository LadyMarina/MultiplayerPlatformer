using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class User : MonoBehaviour
    {
        public enum Type
        {
            Character, Controller
        }

        public Type type;
    }   
}
