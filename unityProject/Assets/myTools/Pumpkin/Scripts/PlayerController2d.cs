using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2d : MonoBehaviour
{

    // Stats for movement
    public float speed;
    public float jumpForce;
    public float moveInput;

    // Rigidbody 
    //private Rigidbody2D rb;
    private bool isFacingRight = true;

    // Jumping
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool doubleJump;




    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<CharacterController>();
    }

    // Update for fixed number of frames
    void FixedUpdate()
    {
        //define what is the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
       // rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // If player is moving right, flip player right
        if(!isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }
        // If player is moving left, flip player left
        else if (isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
    }

    // Update used as we need every frame
    void Update()
    {
        if(isGrounded)
        {
            doubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
         //   rb.velocity = Vector2.up * jumpForce;
            doubleJump = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
         //   rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //stores localscale
        scaler.z *= -1;
        transform.localScale = scaler;
    }
}
