using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetPlayerManager : NetworkBehaviour
{
    [SerializeField] FirstPersonController myController;
    [SerializeField] Camera myCamera;

    void Start()
    {
        //Check weather the player object belongs to the client or not and turn on the script and camera if so
        if (isLocalPlayer)// isLocalPlayer returns weather the current playerobject belonges to the client or not
        {
            myController.enabled = true;
            myCamera.enabled = true;
        }

    }


}
