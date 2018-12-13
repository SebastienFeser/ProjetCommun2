using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    [SerializeField] Rigidbody2D playerRigidBody2D;
    [SerializeField] float playerMovementSpeed = 5f;
    bool isMovingRight;
    bool isMovingLeft;
    
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            isMovingRight = true;
            isMovingLeft = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
        else
        {
            isMovingLeft = false;
            isMovingRight = false;
        }
	}

    private void FixedUpdate()
    {
        if (isMovingRight)
        {
            playerRigidBody2D.velocity = new Vector2(playerMovementSpeed, 0);
        }

        if (isMovingLeft)
        {
            playerRigidBody2D.velocity = new Vector2(-playerMovementSpeed, 0);
        }
        
        if (!isMovingLeft && !isMovingRight)
        {
            playerRigidBody2D.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
