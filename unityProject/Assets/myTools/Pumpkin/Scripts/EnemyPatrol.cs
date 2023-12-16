using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // set enemy move speed
    public float rayDistance; // distance for a ray

    private bool isMovingRight = true; // is enemy moving right
    public Transform groundDetection; // is enemy touching ground

    // Update is called once per frame
    void Update()
    {
        // Move enemy to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Raycast, produces a ray with determined distance from origin
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);

        if(isMovingRight == true)
        {
            // flip enemy when at right edge of a platform
            transform.eulerAngles = new Vector3(0, -180, 0);
            isMovingRight = false;
        }
        else
        {
            // flip enemy when at left edge of platform
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMovingRight = true;
        }
    }
}
