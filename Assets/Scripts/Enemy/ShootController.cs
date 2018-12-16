using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    [SerializeField] private float force;
    [SerializeField] private bool shootTowardBlock;
    public bool ShootTowardBlock
    {
        set { shootTowardBlock = value; }
    }

    [SerializeField] private GameObject target;

    Vector2 toTarget;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        if (!shootTowardBlock)
        {
            rigid.velocity = Vector2.down * force;
        }
        else
        {
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            rigid.velocity = diff * force;
        }
    }

    public void AsignTarget(GameObject targetTo)
    {
        target = targetTo;
        shootTowardBlock = true;
    }

    
}
