using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosLow : MonoBehaviour {
    [SerializeField] private EnemySequence enemySequenceScript;
    [SerializeField] private bool isStuck;
    public bool IsStuck
    {
        get { return isStuck; }
        set { isStuck = value; }
    }
    [SerializeField] private GameObject destroyGM;
    public GameObject DestroyGM
    {
        get { return destroyGM; }
        set { destroyGM = value; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            isStuck = true;
            destroyGM = collision.gameObject;
        }
    }
}
