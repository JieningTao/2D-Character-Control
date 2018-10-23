using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    public float maxSpeed = 0.1f;
    public float jumpforce = 1000f;
    bool facingRight = true;
    private Rigidbody2D ThisRigidBody2D;
    private Animator anim;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadius = 0.2f;

	// Use this for initialization
	void Start ()
    {
        ThisRigidBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    bool grounded()
    {

        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
            return true;
        else
            return false;
    }
	
	void FixedUpdate ()
    {
        anim.SetBool("Grounded", grounded());
        anim.SetFloat("Vertical speed", ThisRigidBody2D.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        ThisRigidBody2D.velocity = new Vector2(move * maxSpeed, ThisRigidBody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        


	}

     void Update()
    {
        if (grounded() && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Grounded", false);
            ThisRigidBody2D.AddForce(new Vector2(0, jumpforce));
        }                
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
