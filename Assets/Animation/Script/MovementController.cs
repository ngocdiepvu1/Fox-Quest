using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public float maxHeight = 1.0f;
    bool facingRight = true;

    AudioSource jumpSound;
    Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();

        if (!facingRight)
            FlipFacing();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        var timer = 0.5f;
        var time = 0.5f;
        var height = 0.0f;
        var startPos = transform.position;
        var endPos = transform.position;

        //Getting the info from the InputManager
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        //Flip character according to moving direction
        if (move > 0.01 && !facingRight)
            FlipFacing();
        else if (move < 0 && facingRight) 
            FlipFacing(); 

        //Setting the height of the jump
        if (Input.GetButton("Jump"))
        {
            if (jumpSound.isPlaying == false)
                jumpSound.Play();

            while (timer <= 1.0f ) 
            {
                height = Mathf.Sin(Mathf.PI * timer) * maxHeight;
                transform.position = Vector3.Lerp(startPos, endPos, timer) + Vector3.up * height;
                timer += Time.deltaTime / time;
            }
        }
        //Right click to lie down
        if (Input.GetMouseButtonDown(1)) {
            anim.SetFloat("Mouse", 2);
        }

        //Left click to back to running
        if (Input.GetMouseButtonDown(0)) {
            anim.SetFloat("Mouse", 0);
        }
    }

    void FlipFacing()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1.0f;
        transform.localScale = charScale;
    }
}
