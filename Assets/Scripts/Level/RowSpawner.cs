using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] rows;
    [SerializeField] private beeType[] posTypes;
    [SerializeField] private GameObject beeNormal, beeShoot, beeFat;
    [SerializeField] private int rowID;
    [SerializeField] private Transform[] posTransf;
    public Transform[] PosTransf
    {
        get { return posTransf; }
    }

    private int posID;

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
                EnemyController controller = bee.GetComponent<EnemyController>();

                //Get Near Enemies
                if (i > 0)
                {
                    controller.AddNearEnemy(posTransf[i - 1].gameObject);
                }
                if (i < 4)
                {
                    controller.AddNearEnemy(posTransf[i + 1].gameObject);
                }

                if(rowID == 0)
                {
                    controller.AddNearEnemy(rows[rowID + 1].GetComponent<RowSpawner>().posTransf[i].gameObject);
                    controller.AddNearEnemy(rows[rowID + 2].GetComponent<RowSpawner>().posTransf[i].gameObject);

                }
                else if(rowID == 1)
                {
                    controller.AddNearEnemy(rows[rowID - 1].GetComponent<RowSpawner>().posTransf[i].gameObject);
                    controller.AddNearEnemy(rows[rowID + 1].GetComponent<RowSpawner>().posTransf[i].gameObject);
                }
                else if (rowID == 2)
                {
                    controller.AddNearEnemy(rows[rowID - 1].GetComponent<RowSpawner>().posTransf[i].gameObject);
                    controller.AddNearEnemy(rows[rowID - 2].GetComponent<RowSpawner>().posTransf[i].gameObject);
                }



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
