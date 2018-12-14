using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour {
    [SerializeField] Rigidbody2D playerRigidBody2D;
    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] float life = 100;
    [SerializeField] Image lifeBar;
    float lifeBarSize;
    [SerializeField] float projectilesDamages = 20;

    bool isMovingRight;
    bool isMovingLeft;
    
	void Start () {
        lifeBarSize = life;
		
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
        if (collision.gameObject.tag == "Enemy_Projectile")
        {
            life -= projectilesDamages;
            lifeBar.fillAmount = life / lifeBarSize;
            Destroy(collision.gameObject);
        }
    }
}
