using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using TMPro;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] NetworkManager networkManager;
    [SerializeField] TMP_InputField inputField;

    public void HostButtonEvent()
    {
        networkManager.StartHost();
    }

    public void JoinButtonEvent()
    {
        networkManager.networkAddress = inputField.text;
        networkManager.StartClient();
    }

}
