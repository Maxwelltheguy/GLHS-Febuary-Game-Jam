using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSFXController : NetworkBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip jumpPadClip;
    [SerializeField] AudioClip throwClip;

 
    public void PlayJumpSFX()
    {
        audioSource.clip = jumpClip;
        audioSource.Play();
    }
    public void PlayJumpPadSFX()
    {
        audioSource.clip = jumpPadClip;
        audioSource.Play();
    }
    public void ThrowSFX()
    {
        audioSource.clip = throwClip;
        audioSource.Play();
    }
}
