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
    [SerializeField] SkinnedMeshRenderer playerMesh;
    [SerializeField] Material[] materials;
    [SyncVar] int selectedColor;
    //EscMenu EscMenu;

    private void Start()
    {
        //EscMenu = FindAnyObjectByType<EscMenu>();
        if (isLocalPlayer)
        {
            selectedColor = Random.Range(0, materials.Length);
        }
        
    }

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
        if (playerMesh != null)
        {
            playerMesh.material = materials[selectedColor];
        }

    }
}
