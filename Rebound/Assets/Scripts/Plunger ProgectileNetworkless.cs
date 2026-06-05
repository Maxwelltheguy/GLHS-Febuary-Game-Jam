using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerProgectileNetworkless : MonoBehaviour
{
    public float projSpeed;
    public float projPowerMult;
    public int projCooldown;
    public string damageType = "Basic";
    [SerializeField] bool plungerCodeOff = false;
    


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
                
            }
            
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
