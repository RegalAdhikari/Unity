using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator anim;
    public bool grounded;
    public  float MoveSpeed;
    public float JumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * MoveSpeed, body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKeyDown("space") && grounded)
        {
            Jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
   
         body.velocity = new Vector2(body.velocity.x, JumpSpeed);
        grounded = false;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Checks if it has a ground tag 
            grounded = true;
    }
}
