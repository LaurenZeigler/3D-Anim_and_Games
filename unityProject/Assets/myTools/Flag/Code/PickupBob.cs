using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBob : MonoBehaviour
{
    [Header("Bobbing motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPos;

    // Update is called once per frame
    void Update()
    {
        //Rotates pickup around y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime); // Spin in another direction
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // SPIN BANABA SPIN CAN YOU FEEL IT YES FEEL THE SPEED  GO Go oO

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));

        //transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if (transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
