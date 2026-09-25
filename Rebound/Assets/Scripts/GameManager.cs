using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [SyncVar] string gamemode = "classic";

    [SyncVar] public string currLeadUser = null;
    [SyncVar] public int currHighScore;

    private void Start()
    {

        if (isServer)
        {
            gamemode = FindObjectOfType<ServerSettings>().gamemode;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void DeclareWinner()
    {
        
    }

    // Not used for classic as the logic does not work with it
    public void CheckPlayerScore(int score, string user)
    {
        if (score == 0)
        {
            currLeadUser = user;
        }
        else if (score == currHighScore)
        {
            if (currLeadUser != null )
            {
                currLeadUser = currLeadUser + ", and " + user;
            }
            else
            {
                currLeadUser = user;
            }
        }
        else if (score > currHighScore)
        {
            currHighScore = score;
        }
    }

}
