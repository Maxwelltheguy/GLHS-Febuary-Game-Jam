using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlungerProgectile : NetworkBehaviour
{
    [SerializeField] float projSpeed;
    [SerializeField] NetworkManager networkManager;

    private void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
    }
    void Update()
    {
        transform.position = transform.position + (transform.forward * projSpeed) * Time.deltaTime;// + new Vector3(0,0,projSpeed)
        if (transform.position.x < 100 &  transform.position.x > -100 & transform.position.y < 100 & transform.position.y > -100 & transform.position.z < 100 & transform.position.z > -100)
        {

        }
        else
        {
            NetworkServer.Destroy(gameObject);
        }
    }

    
}
