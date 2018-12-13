using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    [SerializeField] private float force;

    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * force;
    }
}
