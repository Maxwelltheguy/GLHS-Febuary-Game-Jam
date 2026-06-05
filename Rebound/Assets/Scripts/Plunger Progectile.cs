using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlungerProgectile : NetworkBehaviour
{
    public float projSpeed;
    public float projPowerMult;
    public int projCooldown;
    public string damageType = "Basic";
    [SerializeField] bool plungerCodeOff = false;
    [SerializeField] bool checkForOwnership = true;
    [SerializeField] NetworkManager networkManager;

    private void Start()
    {
        if (isOwned & checkForOwnership)
        {
            gameObject.tag = "MyAttack";
        }
        networkManager = FindObjectOfType<NetworkManager>();
        
    }
    void Update()
    {
        if (plungerCodeOff == false)
        {
            transform.position = transform.position + (transform.forward * projSpeed) * Time.deltaTime;// + new Vector3(0,0,projSpeed)
            if (transform.position.x < 100 & transform.position.x > -100 & transform.position.y < 100 & transform.position.y > -100 & transform.position.z < 100 & transform.position.z > -100)
            {

            }
            else
            {
                Destroy(gameObject);
                NetworkServer.Destroy(gameObject);
            }
        }
        if (!isOwned & checkForOwnership)
        {
            gameObject.tag = "Attack";
        }
    }

    public void DestroyObject()
    {
        NetworkServer.Destroy(gameObject);
    }
}
