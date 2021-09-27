using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterCamera : ICameraController
    {
        public void UpdatePosition(Camera camera, float speed, float deltaTime)
        {
            camera.transform.position += (Vector3)Vector2.right * speed * deltaTime;
        }
    }
}
