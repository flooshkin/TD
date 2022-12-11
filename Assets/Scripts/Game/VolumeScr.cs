using UnityEngine;

public class VolumeScr : MonoBehaviour
{
    public float volume = 20f;
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
