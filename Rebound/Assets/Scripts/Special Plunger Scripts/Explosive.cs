using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Explosive : NetworkBehaviour
{
    [SerializeField] GameObject explosionObject;
    [SerializeField] float scaleLimit = 10f;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 23, ForceMode.Impulse);
    }

    private void Update()
    {
        if (explosionObject.transform.localScale.z > scaleLimit)
        {
            NetworkServer.Destroy(gameObject);
            
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (explosionObject != null)
        {
            explosionObject.SetActive(true);
            Destroy(gameObject.GetComponent<Rigidbody>());

        }
    }
}
