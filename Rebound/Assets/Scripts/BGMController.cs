using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGMController : MonoBehaviour
{
    [SerializeField] AudioClip[] Music;
    [SerializeField] AudioClip clipToPlay;
    [SerializeField] AudioSource audioSource;

    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            clipToPlay = Music[Random.Range(0, Music.Length)];
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
        
    }


}
