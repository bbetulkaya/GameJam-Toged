using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] hurtAudioClip;
    public AudioClip jumpClip;
    public AudioClip vampireClip;
    public AudioClip medicine;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ObstacleAudio()
    {
        int rand = Random.Range(0, hurtAudioClip.Length);
        audioSource.clip = hurtAudioClip[rand];
        audioSource.Play();

    }
    public void JumpAudio()
    {

        audioSource.clip = jumpClip;
        audioSource.Play();
    }
    public void VampireClip()
    {
        audioSource.clip = vampireClip;
        audioSource.Play();
    }
    public void MedicineAudio()
    {
        audioSource.clip = medicine;
        audioSource.Play();
    }
}
