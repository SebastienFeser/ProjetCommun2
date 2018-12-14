using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour {
    [SerializeField] private Material iceMaterial, fireMaterial, gazMaterial, electricMaterial;
    [SerializeField] private ParticlesFrisbee particleScript;
    [SerializeField] private EnemyController.deathType typeFrisbee;
    public EnemyController.deathType TypeFrisbee
    {
        set { typeFrisbee = value; }
    }

    [SerializeField] private Sprite normal, ice, gaz, electric, fire;

    private Vector2 frisbeeSpeed;
    public Vector2 FrisbeeSpeed
    {
        set { frisbeeSpeed = value; }
    }
    [SerializeField] Rigidbody2D frisbeeRigidbody;

	void Start () {

        frisbeeRigidbody.velocity = frisbeeSpeed;
        SpriteRenderer spr = GetComponentInChildren<SpriteRenderer>();
        ParticleSystemRenderer partRenderer = particleScript.gameObject.GetComponent<ParticleSystemRenderer>();
        switch (typeFrisbee)
        {
            case EnemyController.deathType.normal:
                spr.sprite = normal;
                partRenderer.enabled = false;
                break;

            case EnemyController.deathType.ice:
                spr.sprite = ice;
                partRenderer.material = iceMaterial;
                break;

            case EnemyController.deathType.gaz:
               spr.sprite = gaz;
                partRenderer.material = gazMaterial;
                break;

            case EnemyController.deathType.electric:
                spr.sprite = electric;
                partRenderer.material = electricMaterial;
                break;

            case EnemyController.deathType.fire:
                spr.sprite = fire;
                partRenderer.material = fireMaterial;
                break;
        }

	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            frisbeeRigidbody.velocity = new Vector2(-(frisbeeRigidbody.velocity.x), frisbeeRigidbody.velocity.y);
        }
        else if (collision.tag == "Roof")
        {
            particleScript.Detatch();
            Destroy(gameObject);
        }
        else if(collision.tag == "Enemy")
        {

            if (typeFrisbee != EnemyController.deathType.fire)
            {
                collision.gameObject.GetComponent<EnemyController>().DestroyBee(typeFrisbee);
                particleScript.Detatch();
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyController>().DestroyBee(typeFrisbee, collision.gameObject);
            }
        }
    }
}
