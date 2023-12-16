using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsound : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioS;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                //Reference Audio Source to play sound effect
                audioS = GetComponent<AudioSource>();
                audioS.PlayOneShot(sound, 1.0f);
        }
    }
}
