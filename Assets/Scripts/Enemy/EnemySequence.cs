using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour {
    [SerializeField] private float moveLength, downLength;
    [SerializeField] private float speed, time;
    [SerializeField] private RowSpawner rowSpawnerScript;
    [SerializeField] private int maxMove = 5;
    [SerializeField] private int freezeTime;
    [SerializeField] private List<GameObject> everyEnemy;
    [SerializeField] private Transform poslow;
    [SerializeField] private bool destroyBlock;
    public bool DestroyBlock
    {
        get { return destroyBlock; }
    }
    
    [SerializeField] private int enemyCount;
    public int EnemyCount
    {
        get { return enemyCount; }
    }

    public float lowestBeePos;
    public GameObject lowestBee;

    private enum moveDir { up, down, left, right};
    private moveDir dir;
    private Vector3 destination;

    private bool hasToMove = true;
    private bool frozen = false;

    private bool isStuck;
    public bool IsStuck
    {
        get { return isStuck; }
        set { isStuck = value; }
    }

    private GameObject target;
    public GameObject Target
    {
        get { return target; }
    }

    private PosLow posLowScript;
    

	void Start () {
        posLowScript = poslow.GetComponent<PosLow>();
        lowestBee = gameObject;
        lowestBeePos = 150;
        StartCoroutine("Sequence");
        FindAllEnemy();
	}

	// Update is called once per frame
	void Update () {
        isStuck = posLowScript.IsStuck;
        target = posLowScript.DestroyGM;
        destroyBlock = isStuck;
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
            if(enemy.transform.position.y < lowestBeePos)
            {
                lowestBeePos = enemy.transform.position.y;
                lowestBee = enemy;
            }
        }
        if (lowestBee != null)
        {
            poslow.position = new Vector2(poslow.position.x, lowestBeePos - lowestBee.transform.localScale.y);
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
                destination = new Vector3(transform.position.x, transform.position.y - downLength, transform.position.z);
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
            while (frozen || isStuck)
            {
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(time);
        }

        while (hasToMove)
        {
            //Move Down
            
            while (frozen || isStuck)
            {
                yield return new WaitForSeconds(0.05f);
            }
            Move(moveDir.down);
            yield return new WaitForSeconds(time);

            //Move Left
            for (int i = 0; i < maxMove * 2; i++)
            {
                
                while (frozen || isStuck)
                {
                    yield return new WaitForSeconds(0.05f);
                }
                Move(moveDir.left);
                yield return new WaitForSeconds(time);
            }

            //Move Down
            
            while (frozen || isStuck)
            {
                yield return new WaitForSeconds(0.05f);
            }
            Move(moveDir.down);
            yield return new WaitForSeconds(time);

            //Move Right
            for (int i = 0; i < maxMove * 2; i++)
            {
                
                while (frozen || isStuck)
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
