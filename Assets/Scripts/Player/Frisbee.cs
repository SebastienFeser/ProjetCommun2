using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour {

    
    [SerializeField] private EnemyController.deathType typeFrisbee;
    public EnemyController.deathType TypeFrisbee
    {
        set { typeFrisbee = value; }
    }

    [SerializeField] private Sprite normal, ice, gaz, electric, fire;

    private Vector2 frisbeeSpeed;
    public Vector2 FrisbeeSpeed
    {
        set { frisbeeSpeed = value; }
    }
    [SerializeField] Rigidbody2D frisbeeRigidbody;

	void Start () {
        frisbeeRigidbody.velocity = frisbeeSpeed;
        SpriteRenderer spr = GetComponentInChildren<SpriteRenderer>();
        switch (typeFrisbee)
        {
            case EnemyController.deathType.normal:
                spr.sprite = normal;
                break;

            case EnemyController.deathType.ice:
                spr.sprite = ice;
                break;

            case EnemyController.deathType.gaz:
               spr.sprite = gaz;
                break;

            case EnemyController.deathType.electric:
                spr.sprite = electric;
                break;

            case EnemyController.deathType.fire:
                spr.sprite = fire;
                break;
        }

	}
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Wall")
        {
            frisbeeRigidbody.velocity = new Vector2(-(frisbeeRigidbody.velocity.x), frisbeeRigidbody.velocity.y);
        }
        else if (collision.tag == "Roof")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().DestroyBee(typeFrisbee);
            Destroy(gameObject);
        }
    }
}
