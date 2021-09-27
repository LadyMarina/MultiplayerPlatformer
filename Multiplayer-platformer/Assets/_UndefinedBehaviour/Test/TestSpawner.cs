using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class TestSpawner : NetworkBehaviour
{
    public GameObject testFalling;
    public float betweenTime = 1f;

    public override void OnStopServer()
    {
        base.OnStopServer();
        CancelInvoke("Spawn");
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        InvokeRepeating("Spawn", 0, betweenTime);
    }

    private void Spawn()
    {
        GameObject go = Instantiate(testFalling, transform.position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }
}
