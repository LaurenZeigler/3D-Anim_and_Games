using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GhostEnemy enemy = other.GetComponent<GhostEnemy>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Run the TakeDamage function and apply damage to enemy - enemy code will destroy enemy
            enemy.TakeDamage(damage); 
        }
        Destroy(gameObject); // Destroy projectile
    }
}
