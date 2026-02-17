using Mirror.BouncyCastle.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject canvas; // references the canvas for enabling/disabling


    

    void Update()
    {
        EscMenuEnable(); // calls for esc menu enabling/disabling
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


    }



}


