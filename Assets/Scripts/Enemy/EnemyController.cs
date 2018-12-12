using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private float shootInterval;
    [SerializeField] private beeType type;
    [SerializeField] private int life;
    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    private bool canShoot;
    private enum beeType { normal, shoot, fat };

    void Start () {
        switch (type)
        {
            case beeType.normal:
                canShoot = false;
                break;

            case beeType.shoot:
                canShoot = true;
                break;

            case beeType.fat:
                canShoot = false;
                break;
        }
    }
	
	void Update () {
        if (canShoot)
        {
            canShoot = false;
            StartCoroutine("ShootTimer");
            Invoke("Shoot",0);
        }
	}


    void Shoot()
    {
        Instantiate(shootPrefab, transform.position, transform.rotation);   
    }

    public void DestroyBee()
    {
        Destroy(gameObject);
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
