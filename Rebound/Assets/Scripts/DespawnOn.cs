using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOn : NetworkBehaviour
{
    [SerializeField] bool despawnOnNoChildObjects = false;


    private void Update()
    {
        if (despawnOnNoChildObjects)
        {
            if(transform.childCount == 0)
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }
}
