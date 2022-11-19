using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScr : MonoBehaviour
{
    public float volume = 100f;
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = volume;
    }

    public void ChangeVolume(float vol)
    {
        volume = vol;
    }
}