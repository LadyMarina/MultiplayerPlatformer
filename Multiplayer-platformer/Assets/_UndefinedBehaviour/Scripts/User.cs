using System;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class User
    {
        public enum Type
        {
            Character, God
        }

        private Type _type;

        public User(Type userType)
        {
            _type = userType;
        }
        
        public bool IsUserType(Type type)
        {
            return type == _type;
        }
    }   
}
