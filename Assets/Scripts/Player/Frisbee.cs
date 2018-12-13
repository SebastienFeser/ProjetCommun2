using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour {

    
    [SerializeField] private EnemyController.deathType typeFrisbee;

    private Vector2 frisbeeSpeed;
    public Vector2 FrisbeeSpeed
    {
        set { frisbeeSpeed = value; }
    }
    [SerializeField] Rigidbody2D frisbeeRigidbody;

	void Start () {
        frisbeeRigidbody.velocity = frisbeeSpeed;
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
