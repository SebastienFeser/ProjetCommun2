using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMap : MonoBehaviour {
    [SerializeField] float playerSpeed = 2;

    GameObject up;
    GameObject down;
    GameObject left;
    GameObject right;

    Transform destination;

	// Use this for initialization
	void Start () {
        destination = transform;
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination.transform.position, playerSpeed);



        if (Input.GetButtonDown("Left") && left != null)
        {
            destination = left.transform;
        }

        if (Input.GetButtonDown("Right") && right != null)
        {
            destination = right.transform;
        }

        if (Input.GetButtonDown("Up") && up!= null)
        {
            destination = up.transform;
        }

        if (Input.GetButtonDown("Down") && down != null)
        {
            destination = down.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MapPoint")
        {
            up = null;
            down = null;
            left = null;
            right = null;
            up = collision.gameObject.GetComponent<MapPoints>().upPoint;
            down = collision.gameObject.GetComponent<MapPoints>().downPoint;
            left = collision.gameObject.GetComponent<MapPoints>().leftPoint;
            right = collision.gameObject.GetComponent<MapPoints>().rightPoint;
        }
    }

    
}
