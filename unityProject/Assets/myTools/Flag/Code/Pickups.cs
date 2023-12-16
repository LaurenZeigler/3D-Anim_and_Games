using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;
    private Vector3 startPos;

    bool pickedUp; //
    private Renderer rend; //
    private BoxCollider collide; //

    // Start is called before the first frame update
    void Start()
    {
        //Code for rendering pickup only once, method without destroying
        pickedUp = false; //
        rend = GetComponent<Renderer>(); // 
        collide = GetComponent<BoxCollider>(); //
        rend.enabled = true; //
    }

    public enum PickupType
    {
        Health,
        Ammo
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickedUp == false)
            {
                PlayerController player = other.GetComponent<PlayerController>();

                switch (type)
                {
                    case PickupType.Health:
                        player.GiveHealth(healthAmount);
                        break;

                    case PickupType.Ammo:
                        player.GiveAmmo(ammoAmount);
                        break;

                    default:
                        print("Type not accepted");
                        break;
                }
                
                //Code for rendering pickup only once, method without destroying
                pickedUp = true; //
                rend.enabled = false; //
                collide.enabled = false; //
            }
        }
    }
}
