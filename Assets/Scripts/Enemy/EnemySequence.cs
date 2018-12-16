using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour {
    [SerializeField] private float moveLength;
    [SerializeField] private float speed, time;
    [SerializeField] private RowSpawner rowSpawnerScript;
    [SerializeField] private int maxMove = 5;
    [SerializeField] private int freezeTime;
    [SerializeField] private List<GameObject> everyEnemy;
    [SerializeField] private int enemyCount;
    public int EnemyCount
    {
        get { return enemyCount; }
    }
    

    private enum moveDir { up, down, left, right};
    private moveDir dir;
    private Vector3 destination;

    private bool hasToMove = true;
    private bool frozen = false;

    
    

	void Start () { 
        StartCoroutine("Sequence");
        FindAllEnemy();
	}
	
	// Update is called once per frame
	void Update () {
        FindAllEnemy();
        transform.position = Vector3.Lerp(transform.position, destination, speed/10);
	}

    public void FindAllEnemy()
    {
        everyEnemy.Clear();
       GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemyArray)
        {
            everyEnemy.Add(enemy);
        }

        enemyCount = everyEnemy.Count;

    }

    public void ToggleIce(bool state, bool asLost = default(bool))
    {
        foreach(GameObject enemy in everyEnemy)
        {
            enemy.GetComponent<EnemyController>().ToggleIce(state, asLost);
        }
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
        //Move Right
        for (int i = 0; i < maxMove; i++)
        {
            Move(moveDir.right);
            while (frozen)
            {
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(time);
        }

        while (hasToMove)
        {
            //Move Down
            
            while (frozen)
            {
                yield return new WaitForSeconds(0.05f);
            }
            Move(moveDir.down);
            yield return new WaitForSeconds(time);

            //Move Left
            for (int i = 0; i < maxMove * 2; i++)
            {
                
                while (frozen)
                {
                    yield return new WaitForSeconds(0.05f);
                }
                Move(moveDir.left);
                yield return new WaitForSeconds(time);
            }

            //Move Down
            
            while (frozen)
            {
                yield return new WaitForSeconds(0.05f);
            }
            Move(moveDir.down);
            yield return new WaitForSeconds(time);

            //Move Right
            for (int i = 0; i < maxMove * 2; i++)
            {
                
                while (frozen)
                {
                    yield return new WaitForSeconds(0.05f);
                }
                Move(moveDir.right);
                yield return new WaitForSeconds(time);
            }


        }
    }

   public IEnumerator Freeze()
    {
        frozen = true;
        ToggleIce(true);
        yield return new WaitForSeconds(freezeTime);
        frozen = false;
        ToggleIce(false);
        
    }

    public void Stop()
    {
        frozen = true;
        ToggleIce(false, true);
    }
}
