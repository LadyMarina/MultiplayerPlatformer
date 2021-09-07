using System;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class User : MonoBehaviour
    {
        public enum Type
        {
            Character, God
        }

        private Type _type;

        public bool IsUserType(Type type)
        {
            return type == _type;
        }
    }   
}
