using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Threading;

public class NetPlayerManager : NetworkBehaviour
{
    [SerializeField] FirstPersonController myController;
    [SerializeField] Camera myCamera;
    [SerializeField] Transform plungerThrowTransform;
    [SerializeField] GameObject plungerObject;
    [SerializeField] NetworkManager networkManager;
    [SerializeField] GameObject meleeObject;
    [SerializeField] int meleeTimer;
    [SyncVar] bool meleeActive = false;

    void Start()
    {
        //Check weather the player object belongs to the client or not and turn on the script and camera if so
        if (isLocalPlayer)// isLocalPlayer returns weather the current playerobject belonges to the client or not
        {
            myController.enabled = true;
            myCamera.enabled = true;
        }
        networkManager = FindObjectOfType<NetworkManager>();
        
    }

    private void Update()
    {
        if (meleeTimer > 0 &isLocalPlayer)
        {
            meleeActive = true;
        }
        else if (isLocalPlayer)
        {
            meleeActive = false;
        }
        if (meleeActive == true)
        {
            meleeObject.SetActive(true);

        }
        else
        {
            meleeObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) & isLocalPlayer)
        {
            cmdItemThrowSpawn();
        }
        else if (Input.GetMouseButtonDown(1) & isLocalPlayer)
        {
            meleeTimer = 10;

        }
        
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer && meleeActive)
        {
            meleeTimer--;
        }
    }

    [Command]
    void cmdItemThrowSpawn()
    {

        GameObject obj = plungerObject;
        Transform pos = plungerThrowTransform;
        obj.transform.position = pos.position;
        obj.transform.rotation = pos.rotation;
        obj = Instantiate(obj);
        NetworkServer.Spawn(obj);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = networkManager.GetStartPosition().position;
        }
    }
}
