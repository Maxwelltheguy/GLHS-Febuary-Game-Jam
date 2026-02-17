using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Mirror;
using Mirror.BouncyCastle.Security;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject canvas; // references the canvas for enabling/disabling
    [SerializeField] NetworkManager networkManager;
    [SerializeField] TMP_Text ipText;

    private void Start()
    {
        networkManager = FindAnyObjectByType<NetworkManager>();
    }

    void Update()
    {
        EscMenuEnable(); // calls for esc menu enabling/disabling
        ipText.text = GetLocalIPAddress();
    }


    private void EscMenuEnable() // allows esc menu to be enabled/disabled by pressing esc
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.active == true)
            {
                canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

        }
    }


    public void QuitToMenu()
    {
        networkManager.StopClient();
        networkManager.StopServer();

    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                //hintText.text = ip.ToString();
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }


}


