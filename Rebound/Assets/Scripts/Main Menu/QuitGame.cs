using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor; 

public class QuitGame : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    void Start()
    {
        // looks out for click
        //quitButton.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game now >:(");

// if in the unity editor
        //EditorApplication.isPlaying = false;
// if in build
        Application.Quit();

    }
}