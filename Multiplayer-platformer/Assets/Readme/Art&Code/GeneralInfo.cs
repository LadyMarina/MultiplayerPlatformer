using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour
{
    [CreateAssetMenu(fileName = "General Info", menuName = "Undefined Behaviour/General Info")]
    public class GeneralInfo : ScriptableObject
    {
        public Texture2D TopImage;
        public string Description;
        public List<Link> ProjectLinks = new List<Link>();
        public List<Link> UndefinedBehaviourLinks = new List<Link>();
    }

    [Serializable]
    public struct Link
    {
        public string Name;
        public string URL;
    }
}

