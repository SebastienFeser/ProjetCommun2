using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRoof : MonoBehaviour {
    [SerializeField] private GameObject shoot;
    [SerializeField] private float minPos, maxPos;
    [SerializeField] private float frequency;

	// Use this for initialization
	void Awake () {
        StartCoroutine("Shoot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator Shoot()
    {
        while (true)
        {
            float rdmnPos = Random.Range(minPos, maxPos);
            Instantiate(shoot, new Vector2(rdmnPos, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(frequency);
        }
    }
}
