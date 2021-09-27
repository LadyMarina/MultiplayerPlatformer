using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CameraController : MonoBehaviour
    {
        private ICameraController _controller;
        private Camera _camera;

        public User user { get; set; }

        
        private void Start()
        {
            _camera = Camera.main;

            if (user.IsUserType(User.Type.Character))
                _controller = new CharacterCamera();
            else
                _controller = new GodCamera();
        }

        private void Update()
        {
            _controller.UpdatePosition(_camera, LevelManager.Instance.Scroller.GetSpeed(), Time.deltaTime);
        }
    }
}
