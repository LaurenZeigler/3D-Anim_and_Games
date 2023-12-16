using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    private Health playerHealth; 
    public int damage = 1;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Player takes " + damage + "points of damage");
        }
    }
}
