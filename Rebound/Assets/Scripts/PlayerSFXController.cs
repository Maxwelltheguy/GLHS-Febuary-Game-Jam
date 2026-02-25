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
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip respawnClip;
 
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
    public void PlayHitSFX()
    {
        audioSource.clip = hitClip;
        audioSource.Play();
    }

    public void PlayRespawnSFX()
    {
        audioSource.clip = respawnClip;
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = throwClip;
            audioSource.Play();
        }
    }
}
