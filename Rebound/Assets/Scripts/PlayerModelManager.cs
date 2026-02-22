using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting.AssemblyQualifiedNameParser;

public class PlayerModelManager : NetworkBehaviour
{
    [SerializeField] GameObject rotationRef;
    [SerializeField] GameObject torsoBone;
    [SyncVar] Quaternion targetRotation = Quaternion.identity;
    
    void Update()
    {

        if (!isLocalPlayer)
        {
            torsoBone.transform.rotation = targetRotation;
            torsoBone.transform.Rotate(new Vector3(0, 90, 0));
        }
        else
        {
            targetRotation = rotationRef.transform.rotation;
        }
        
    }
}
