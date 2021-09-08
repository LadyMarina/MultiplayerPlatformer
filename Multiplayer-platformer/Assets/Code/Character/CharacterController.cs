using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class CharacterController : NetworkBehaviour
    {
        private void Awake()
        {
            GetComponent<CameraController>().user = new User(User.Type.Character);
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            
        }
    }
}
