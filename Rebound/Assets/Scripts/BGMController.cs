using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGMController : MonoBehaviour
{
    [SerializeField] AudioClip[] Music;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = Music[Random.Range(0, Music.Length)];
        audioSource.Play();
    }


}
