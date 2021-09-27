using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class TestAuthority : NetworkBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(isClient)
            Debug.Log("I'm Client");
        else
            Debug.Log("I'm Server");
    }
}
