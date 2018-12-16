using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoints : MonoBehaviour {

    [SerializeField] GameObject leftPoint;
    [SerializeField] GameObject rightPoint;
    [SerializeField] GameObject upPoint;
    [SerializeField] GameObject downPoint;

    [SerializeField] GameObject player;
    [SerializeField] float playerSpeed;

    bool canMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((gameObject.transform.position.x - player.transform.position.x < 0.05f || gameObject.transform.position.x - player.transform.position.x > -0.05f) && (gameObject.transform.position.y - player.transform.position.y < 0.05f || gameObject.transform.position.y - player.transform.position.y > -0.05f))
        {
            canMove = true;
        }

		
	}

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (Input.GetAxis("Horizontal") > 0 && rightPoint != null)
            {
                Debug.Log("Go right");
                transform.position = Vector3.Lerp(transform.position, rightPoint.transform.position, playerSpeed);
            }
            if (Input.GetAxis("Horizontal") < 0 && leftPoint)
            {
                transform.position = Vector3.Lerp(transform.position, leftPoint.transform.position, playerSpeed);

            }
            if (Input.GetAxis("Vertical") > 0 && upPoint != null)
            {
                transform.position = Vector3.Lerp(transform.position, upPoint.transform.position, playerSpeed);

            }
            if (Input.GetAxis("Vertical") < 0 && downPoint != null)
            {
                transform.position = Vector3.Lerp(transform.position, downPoint.transform.position, playerSpeed);

            }
        }
    }
}
