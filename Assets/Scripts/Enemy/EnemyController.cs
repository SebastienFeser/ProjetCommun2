using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private Animator spriteAnimator;
    [SerializeField] private GameManager gameManagerScript;
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject particlesDeath;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private float shootIntervalMin, shootIntervalMax;
    [SerializeField] private beeType type;
    [SerializeField] private int value;
    [SerializeField] private int life;
    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    [SerializeField] private List<GameObject> enemyGaz, enemyElectric;

    private enum beeType { normal, shoot, fat };
    public enum deathType { fire, ice, normal, gaz, electric };
    private deathType typeDeath;
    public deathType TypeDeath
    {
        get { return typeDeath; }
    }

    private bool canShoot;
    private bool frozen;
    private EnemySequence enemySequenceScript;


    void Start () {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        enemySequenceScript = GameObject.FindGameObjectWithTag("EnemySequence").GetComponent<EnemySequence>();

        switch (type)
        {
            case beeType.normal:
                canShoot = false;
                break;

            case beeType.shoot:
                canShoot = true;
                StartCoroutine("ShootTimer");
                break;

            case beeType.fat:
                canShoot = false;
                break;
        }
    }
	
	void Update () {
        spriteAnimator.SetBool("isFrozen", frozen);

        if (canShoot)
        {
            StartCoroutine("ShootTimer");
            Invoke("Shoot",0);
        }
	}


    void Shoot()
    {
        if (!frozen)
        {
            GameObject shootObj = Instantiate(shootPrefab, transform.position, transform.rotation);
            if (enemySequenceScript.IsStuck)
            {
                shootObj.GetComponent<ShootController>().AsignTarget(enemySequenceScript.Target);
            }
        }
    }

    public void DestroyBee(deathType type, GameObject toDestroy = default(GameObject))
    {
        switch (type)
        {
            case deathType.normal:
                DestroySequence(gameObject);
                break;

            case deathType.electric:
                foreach (GameObject enemy in enemyElectric)
                {
                    if (enemy != null)
                    {
                        DestroySequence(enemy);
                    }
                }
                DestroySequence(gameObject);
                break;

            case deathType.fire:
                DestroySequence(toDestroy);
                break;

            case deathType.gaz:
                foreach (GameObject enemy in enemyGaz)
                {
                    if (enemy != null)
                    {
                       DestroySequence(enemy);
                    }
                }

                foreach (GameObject enemy in enemyElectric)
                {
                    if (enemy != null)
                    {
                        DestroySequence(enemy);
                    }
                }
                DestroySequence(gameObject);
                break;

            case deathType.ice:
                enemySequenceScript.StartCoroutine("Freeze");
                break;
        }
    }

    public void AddNearEnemy(GameObject enemy, string type)
    {
        switch (type)
        {
            case "Electric":
                enemyElectric.Add(enemy);
                break;

            case "Gaz":
                enemyGaz.Add(enemy);
                break;
        }
    }

    IEnumerator ShootTimer()
    {
        canShoot = false;
        float RDMN;
        if (!enemySequenceScript.DestroyBlock)
        {
            RDMN = Random.Range(shootIntervalMin, shootIntervalMax);
        }
        else
        {
            RDMN = 0.5f;
        }
        yield return new WaitForSeconds(RDMN);
        canShoot = true;
    }

    void remove()
    {
        DestroyBee(deathType.electric);
    }

    public void ToggleIce(bool state, bool asLost)
    {
        if (!asLost)
        { 
            ice.SetActive(state);
            frozen = state;
        }
        else
        {
            frozen = true;
        }
    }

    public void DestroySequence(GameObject enemyToDestroy)
    {
        gameManagerScript.AddMoney(value);
        Instantiate(particlesDeath, enemyToDestroy.transform.position, Quaternion.identity);
        Destroy(enemyToDestroy);
    }
}
