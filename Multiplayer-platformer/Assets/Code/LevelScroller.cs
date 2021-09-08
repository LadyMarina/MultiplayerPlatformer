using System;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class LevelScroller : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 5.0f;
        private bool _IsScrolling = false;

        private void Awake()
        {
            StartScrolling();
        }

        public void StartScrolling()
        {
            _IsScrolling = true;
        }

        public void StopScrolling()
        {
            _IsScrolling = false;
        }

        public float GetSpeed()
        {
            if (_IsScrolling)
                return _scrollSpeed;
            else
                return 0.0f;
        }
    }
}