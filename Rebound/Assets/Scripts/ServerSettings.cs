using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerSettings : MonoBehaviour
{
    public string gamemode = "classic";
    public int gameTimeSec = 600;

    NetworkManager networkManager;
    [SerializeField] string[] levelScenes;
    [SerializeField] string[] gamemodes;
    [SerializeField] TMP_Dropdown sceneDrop;
    [SerializeField] TMP_Dropdown modeDrop;

    private void Start()
    {
        networkManager = gameObject.GetComponent<NetworkManager>();
    }


    public void SetGamemode()
    {
        gamemode = gamemodes[modeDrop.value];
    }

    public void ChangeMapToValue()
    {
        networkManager.onlineScene = levelScenes[sceneDrop.value];
    }
}
