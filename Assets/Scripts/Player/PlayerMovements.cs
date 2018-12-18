using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour {
    [SerializeField] GameManager GM;
    [SerializeField] Rigidbody2D playerRigidBody2D;
    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float life = 100;
    public float Life
    {
        get { return life; }
    }
    [SerializeField] Image lifeBar;
    float lifeBarSize;
    [SerializeField] float projectilesDamages = 20;

    bool isMovingRight;
    bool isMovingLeft;

    private Animator animatorComponent;

	void Start () {
        animatorComponent = spriteRenderer.GetComponent<Animator>();
        lifeBarSize = life;
        Invoke("SetLife", 0.2f);
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

        spriteRenderer.flipX = isMovingRight;
        bool isWalking = isMovingLeft || isMovingRight;
        animatorComponent.SetBool("isWalking", isWalking);
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

    void SetLife()
    {
        life = GM.MaxLife;
        lifeBarSize = life;
    }
}
