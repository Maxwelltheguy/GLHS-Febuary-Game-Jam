using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlungerProgectile : NetworkBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.localPosition = transform.localPosition + Vector3.forward * Time.deltaTime;
    }
}
