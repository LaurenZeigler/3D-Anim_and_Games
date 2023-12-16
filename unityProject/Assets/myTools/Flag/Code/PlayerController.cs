using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Status")]
    public float curHp;
    public float maxHp;
    public float curAmmo;
    public float maxAmmo;

    // Movement
    [Header("Player Movement")]
    public float moveSpeed;
    public float jumpForce;

    // Looking around
    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;

    // Connect to camera
    private Camera theCamera;
    private Rigidbody rb; //Rigidbody

    //private Weapon weapon;

    /*
    
    Awake
    Start
    Update

    -- Movement and Function
    CameraLook
    Move
    Jump

    -- Status changes
    TakeDamage
    Die
    GiveHealth
    GiveAmmo

    */



    // Awake is before the start function
    void Awake()
    {
        curHp = maxHp;
        // Get component
        theCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        //? theCamera = Camera.main;
        //? rb = GetComponent<Rigidbody>();
        //weapon = GetComponent<Weapon>();
    }
    void Start()
    {
        //Get components

        /* // Initialize the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo); */
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();

        /* // Fire Button
         if(input.GetButton("Fire1"))
        {
           if(weapon.CanShoot())
             weapon.Shoot();
        }*/

        // Jump Button
        if (Input.GetButtonDown("Jump"))
            Jump();

        /* // Don't do anything if the game is paused!!
        if(GameManager.instance.gamePaused == true)
            return;*/
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Up and Down
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Left and Right

        // Drives camera rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        theCamera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Input for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; // Input for forward and back movement

        // Move a direction based on the camera
        Vector3 dir = (transform.right * x) + (transform.forward * z);

        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        
        if(Physics.Raycast(ray, 1.1f))
        {
            // Add force to the jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    // Applies damage to the player
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if (curHp <= 0)
            Die();

        // GameUI.instance.UpdateHealthbar(curHp, maxHp);
    }

    // health below 0 causes player to die
    void Die()
    {
        //GameManager.instance.LoseGame();
        Debug.Log("Game over!");
    }

    public void GiveHealth(int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        //GameUI.instance.UpdateHealthBar(curHp, maxHp);
        Debug.Log("Player given health.");
    }

    public void GiveAmmo(int amountToGive)
    {
        //weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        Debug.Log("Player given ammo.");
    }

}
