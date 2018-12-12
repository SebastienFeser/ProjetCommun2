using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour {
    [SerializeField] private float moveLength;
    [SerializeField] private float speed, time;
    [SerializeField] private RowSpawner rowSpawnerScript;

    private enum moveDir { up, down, left, right};
    private moveDir dir;
    private Vector3 destination;

    private bool hasToMove = true;
    private const int maxMove = 5;
 

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
                destination = new Vector3(transform.position.x - moveLength, transform.position.y, transform.position.z);
                break;

            case moveDir.right:
                destination = new Vector3(transform.position.x + moveLength, transform.position.y, transform.position.z);
                break;
        }
    }

    IEnumerator Sequence()
    {
        int moveLength = maxMove - (rowSpawnerScript.BeeRowNumber - 1) / 2;
        //Move Right
        for (int i = 0; i < moveLength; i++)
        {
            Move(moveDir.right);
            yield return new WaitForSeconds(time);
        }

        while (hasToMove)
        {
            int moveLength_2 = maxMove - (rowSpawnerScript.BeeRowNumber - 1) / 2;

            //Move Down
            Move(moveDir.down);
            yield return new WaitForSeconds(time);


            //Move Left
            for (int i = 0; i < moveLength_2 * 2; i++)
            {
                Move(moveDir.left);
                yield return new WaitForSeconds(time);
            }

            //Move Down
            Move(moveDir.down);
            yield return new WaitForSeconds(time);

            //Move Right
            for (int i = 0; i < moveLength_2 * 2; i++)
            {
                Move(moveDir.right);
                yield return new WaitForSeconds(time);
            }
        }
    }
}
