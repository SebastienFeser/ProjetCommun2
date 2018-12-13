using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public bool deleteme;
    [SerializeField] private GameObject particlesDeath;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private float shootIntervalMin, shootIntervalMax;
    [SerializeField] private beeType type;
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

    void Start () {

        if (deleteme)
        {
            //Invoke("remove", 3);
        }
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
        if (canShoot)
        {
            StartCoroutine("ShootTimer");
            Invoke("Shoot",0);
        }
	}


    void Shoot()
    {
        Instantiate(shootPrefab, transform.position, transform.rotation);   
    }

    public void DestroyBee(deathType type)
    {
        switch (type)
        {
            case deathType.normal:
                Instantiate(particlesDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;

            case deathType.electric:
                foreach (GameObject enemy in enemyElectric)
                {
                    Instantiate(particlesDeath, enemy.transform.position, Quaternion.identity);
                    Destroy(enemy);
                }
                Instantiate(particlesDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;

            case deathType.fire:

                break;

            case deathType.gaz:
                foreach (GameObject enemy in enemyGaz)
                {
                    if (enemy != null)
                    {
                        Instantiate(particlesDeath, enemy.transform.position, Quaternion.identity);
                        Destroy(enemy);
                    }
                }

                foreach (GameObject enemy in enemyElectric)
                {
                    if (enemy != null)
                    {
                        Instantiate(particlesDeath, enemy.transform.position, Quaternion.identity);
                        Destroy(enemy);
                    }
                }
                Instantiate(particlesDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;

            case deathType.ice:

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
        float RDMN = Random.Range(shootIntervalMin, shootIntervalMax);
        yield return new WaitForSeconds(RDMN);
        canShoot = true;
    }

    void remove()
    {
        DestroyBee(deathType.electric);
    }
}
