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
    [SerializeField] GameObject[] plungerObject;
    [SerializeField] NetworkManager networkManager;
    [SerializeField] GameObject meleeObject;
    [SerializeField] int meleeTimer;
    public float plungerTimer; //public for debuging
    [SerializeField] Animator animator;
    [SerializeField] PlayerSFXController sfxController;
    [SyncVar] bool meleeActive = false;
    [SyncVar] bool plungerActive = false;
    [SyncVar] public bool isPlayerWalking = false;
    [SyncVar] int currPlunger = 0;

    void Start()
    {
        //Check weather the player object belongs to the client or not and turn on the script and camera if so
        if (isLocalPlayer)// isLocalPlayer returns weather the current playerobject belonges to the client or not
        {
            myController.enabled = true;
            myCamera.enabled = true;
        }
        networkManager = FindObjectOfType<NetworkManager>();
        sfxController = GetComponent<PlayerSFXController>();
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
        if (plungerTimer > 0 & isLocalPlayer)
        {
            plungerActive = false;
        }
        else if (isLocalPlayer)
        {
            plungerActive = true;
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
            if (plungerActive)
            {
                currPlunger = PlayerPrefs.GetInt("currPlunger", 0);

                //Sets Cooldown
                plungerTimer = plungerObject[currPlunger].GetComponent<PlungerProgectile>().projCooldown;
                sfxController.PlayThrowSFX();
                cmdItemThrowSpawn(gameObject, currPlunger);
                animator.SetTrigger("Throw");
            }
            
            
        }
        else if (Input.GetMouseButtonDown(1) & isLocalPlayer)
        {
            meleeTimer = 10;
            animator.SetTrigger("Slap");
        }
        if (myController.isWalking & isLocalPlayer)
        {
            animator.SetBool("IsWalking", true);

        }
        else if (isLocalPlayer)
        {
            animator.SetBool("IsWalking", false);

        }
        

    }

    private void FixedUpdate()
    {
        if (isLocalPlayer )
        {
            meleeTimer--;
            plungerTimer--;
        }
    }

    [Command]
    void cmdItemThrowSpawn(GameObject player, int plunger)
    {

        GameObject obj = plungerObject[plunger];
        Transform pos = plungerThrowTransform;
        obj.transform.position = pos.position;
        obj.transform.rotation = pos.rotation;
        obj = Instantiate(obj);
        
        NetworkServer.Spawn(obj, player);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = networkManager.GetStartPosition().position;
            sfxController.PlayRespawnSFX();
        }
    }
}
