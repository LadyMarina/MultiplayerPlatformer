using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 30f;
    
    private void Update()
    {
        if (!isLocalPlayer) return;

        float inputX = Input.GetAxis("Horizontal");
        
        transform.position += new Vector3(inputX * speed, 0) * Time.deltaTime;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        FindObjectOfType<CinemachineVirtualCamera>().m_Follow = this.transform;
    }
}
