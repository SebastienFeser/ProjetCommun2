﻿using System.Collections;
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

    [SerializeField] private List<GameObject> nearEnemy;

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
            Invoke("remove", 3);
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
                foreach(GameObject enemy in nearEnemy)
                {
                    Instantiate(particlesDeath, enemy.transform.position, Quaternion.identity);
                    Destroy(enemy);
                }
                Instantiate(particlesDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;

            case deathType.electric:

                break;

            case deathType.fire:

                break;

            case deathType.gaz:

                break;

            case deathType.ice:

                break;
        }
    }

    public void AddNearEnemy(GameObject enemy)
    {
        nearEnemy.Add(enemy);
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
        DestroyBee(deathType.normal);
    }
}
