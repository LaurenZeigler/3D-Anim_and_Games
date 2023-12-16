using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;
    public AudioClip pickupSFX;
    private BoxCollider collide; //

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find and reference gamemanager
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        collide = GetComponent<BoxCollider>(); //
        collide.enabled = true; //
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Flag collide");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Flag collide with player");
            //Destroy(other.gameObject);
            gm.hasFlag = true; // Get the flag and set bool to true
            rend.enabled = false; // Hide flag when held
            collide.enabled = false; //
        }
    }
}
