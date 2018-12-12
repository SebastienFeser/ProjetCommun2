using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawner : MonoBehaviour {
    [SerializeField] private beeType[] posTypes;
    [SerializeField] private Transform[] posTransf;
    [SerializeField] private GameObject beeNormal, beeShoot, beeFat;

    private int beeRowNumber;
    public int BeeRowNumber
    {
        get { return beeRowNumber; }
    }

    private enum beeType { normal, shoot, fat}


	void Start () {

        beeRowNumber = posTransf.Length;

        for(int i = 0; i < beeRowNumber; i++)
        {
            if(posTypes[i] == beeType.normal)
            {
                GameObject bee = Instantiate(beeNormal, posTransf[i].position, Quaternion.identity);
                bee.transform.SetParent(posTransf[i]);
            }
            else if(posTypes[i] == beeType.shoot)
            {
                GameObject bee = Instantiate(beeShoot, posTransf[i].position, Quaternion.identity);
                bee.transform.SetParent(posTransf[i]);
            }
            else if (posTypes[i] == beeType.fat)
            {
                GameObject bee = Instantiate(beeFat, posTransf[i].position, Quaternion.identity);
                bee.transform.SetParent(posTransf[i]);
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
