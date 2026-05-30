using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR;
using Mirror;

public class PlayerVRManager : NetworkBehaviour
{
    [SerializeField] bool isPlayerInVR = false;
    [SerializeField] PlayerModelManager playerModelManager;
    [SerializeField] Camera nonVRCamera;
    [SerializeField] FirstPersonController playerScript;
    [SerializeField] GameObject progectilePoint;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform rightController;
    [SerializeField] Transform leftHand;
    [SerializeField] Transform leftController;

    private void Start()
    {
        if (PlayerPrefs.GetInt("VRMode", 0) == 0)
        {
            isPlayerInVR = false;
        }
        else
        {
            isPlayerInVR = true;
        }
        if (isPlayerInVR)
        {
            gameObject.transform.parent.localRotation = new Quaternion();
            nonVRCamera.enabled = false;
            //playerModelManager.enabled = false;
            playerScript.cameraCanMove = false;
            playerScript.playerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
            progectilePoint.transform.SetParent(rightController, false);
            progectilePoint.transform.localPosition = Vector3.zero;
            progectilePoint.transform.Rotate(90, 0, 0);

            
            rightHand.SetParent(rightController);
            rightHand.localRotation = new Quaternion();
            rightHand.transform.Rotate(90, 0, 0);
            rightHand.localPosition = Vector3.zero;
            leftHand.SetParent(leftController);
            leftHand.localRotation = new Quaternion();
            leftHand.transform.Rotate(90, 0, 0);
            leftHand.localPosition = Vector3.zero;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInVR)
        {
            //rightHand.transform.position = rightController.transform.position;
            //leftHand.transform.position = leftController.transform.position;
            //rightHand.rotation = rightController.transform.rotation;
            //leftHand.rotation = leftController.transform.rotation;
            
        }
    }
}
