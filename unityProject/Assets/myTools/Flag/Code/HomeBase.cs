using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;

    public AudioClip sound;
    AudioSource audioS;
    private BoxCollider collide; //

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GameObject.Find("FlagHome").GetComponent<Renderer>();

        rend.enabled = false; //Hide the Flag
        collide = GetComponent<BoxCollider>(); //
        collide.enabled = true; //
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached home base with the flag! The Player has Won!");

            //gm.PlaceFlag(); // Run placeflag from < GameManager > script
            rend.enabled = true; // Make the flag visable to player

            //Reference Audio Source to play sound effect
            audioS = GetComponent<AudioSource>();
            audioS.PlayOneShot(sound, 1.0f);
            collide.enabled = false; //
        }
    }
}
