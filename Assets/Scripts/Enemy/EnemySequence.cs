using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour {
    [SerializeField] private float moveLength;
    [SerializeField] private float speed, time;

    private enum moveDir { up, down, left, right};
    private moveDir dir;
    private Vector3 destination;

	// Use this for initialization
	void Start () {
        StartCoroutine("Sequence");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, destination, speed/10);
	}

    void Move(moveDir direction)
    {
        switch (direction)
        {
            case moveDir.down:
                destination = new Vector3(transform.position.x, transform.position.y - moveLength, transform.position.z);
                break;

            case moveDir.up:
                destination = new Vector3(transform.position.x, transform.position.y + moveLength, transform.position.z);
                break;

            case moveDir.left:
                destination = new Vector3(transform.position.x + moveLength, transform.position.y, transform.position.z);
                break;

            case moveDir.right:
                destination = new Vector3(transform.position.x - moveLength, transform.position.y, transform.position.z);
                break;
        }
    }

    IEnumerator Sequence()
    {
        Move(moveDir.left);
        yield return new WaitForSeconds(time);
        Move(moveDir.down);
        yield return new WaitForSeconds(time);
        Move(moveDir.right);
        yield return new WaitForSeconds(time);
        Move(moveDir.right);
        yield return new WaitForSeconds(time);
        Move(moveDir.down);
        yield return new WaitForSeconds(time);
        Move(moveDir.left);
        yield return new WaitForSeconds(time);
        StartCoroutine("Sequence");
    }
}
