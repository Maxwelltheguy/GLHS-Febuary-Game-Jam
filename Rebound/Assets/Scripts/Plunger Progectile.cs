using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlungerProgectile : NetworkBehaviour
{
    [SerializeField] float projSpeed;

    void Update()
    {
        transform.position = transform.position + (transform.forward * projSpeed) * Time.deltaTime;// + new Vector3(0,0,projSpeed)
    }
}
