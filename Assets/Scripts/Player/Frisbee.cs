using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour {
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

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Wall")
        {
            Debug.Log("lol");
            frisbeeRigidbody.velocity = new Vector2(-(frisbeeRigidbody.velocity.x), frisbeeRigidbody.velocity.y);
        }
    }
}
