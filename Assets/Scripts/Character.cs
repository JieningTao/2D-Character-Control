using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    public float maxSpeed = 0.1f;
    bool facingRight = true;
    private Rigidbody2D ThisRigidBody2D;
    private Animator anim;


	// Use this for initialization
	void Start ()
    {
        ThisRigidBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        ThisRigidBody2D.velocity = new Vector2(move * maxSpeed, ThisRigidBody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
