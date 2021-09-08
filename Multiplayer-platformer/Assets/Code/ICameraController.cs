using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public interface ICameraController
    {
        void UpdatePosition(Camera camera, float speed, float deltaTime);
    }
}
