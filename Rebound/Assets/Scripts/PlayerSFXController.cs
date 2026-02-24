using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSFXController : NetworkBehaviour
{
    [SerializeField] FirstPersonController controller;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;

 
    public void PlayJumpSFX()
    {
        audioSource.clip = jumpClip;
        audioSource.Play();
    }
}
