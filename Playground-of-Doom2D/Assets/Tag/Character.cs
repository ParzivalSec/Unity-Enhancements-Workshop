using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Enable/disable check for floor objects.
    public bool doCheck = false;

    // Moving the player.
    float speed = 5000.0f;
    float maxSpeed = 5.0f;

    // Only if the player is grounded, jumping is possible.
    bool grounded = true;

    // Easy access of the component: simpler to write and less function calls.
    Rigidbody2D rigidBody;
    
	void Start () {
        // Get reference to the Rigidbody2D component for later use.
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        // Check for movement each frame.
        Move();
	}

    void Move()
    {
        // Prepare a Vector2 which holds movement information. This way, force has to be applied only once.
        Vector2 force = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force += Vector2.left ;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            force += Vector2.up * 30;
        }
        // Take delta time into the equation! This way it runs independently from framerate.
        force *= Time.deltaTime * speed;
        rigidBody.AddForce(force);
        // Limit the speed to a maximum.
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If doCheck is enabled, the player can only jump off objects tagged as "Floor".
        if(doCheck && !col.gameObject.tag.Equals("Floor"))
        {
            return;
        }
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    { 
        grounded = false;
    }
}
