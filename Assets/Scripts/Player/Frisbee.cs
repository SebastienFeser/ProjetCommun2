using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour {
    [SerializeField] private float offset;
    [SerializeField] private Transform trail;
    [SerializeField] private Material iceMaterial, fireMaterial, gazMaterial, electricMaterial;
    [SerializeField] private ParticlesFrisbee particleScript;
    [SerializeField] Rigidbody2D frisbeeRigidbody;
    [SerializeField] private Sprite normal, ice, gaz, electric, fire;

    [SerializeField] private EnemyController.deathType typeFrisbee;
    public EnemyController.deathType TypeFrisbee
    {
        set { typeFrisbee = value; }
    }

    private Vector2 frisbeeSpeed;
    public Vector2 FrisbeeSpeed
    {
        set { frisbeeSpeed = value; }
    }

    private Animator animatorComponent;
    private FxPlayer audioPlayer;

    void Start () {
        audioPlayer = GameObject.FindGameObjectWithTag("FxPlayer").GetComponent<FxPlayer>();
        animatorComponent = trail.GetComponentInChildren<Animator>();
        frisbeeRigidbody.velocity = frisbeeSpeed;
        SpriteRenderer spr = GetComponentInChildren<SpriteRenderer>();
        ParticleSystemRenderer partRenderer = particleScript.gameObject.GetComponent<ParticleSystemRenderer>();
        OrientTrail();
        switch (typeFrisbee)
        {
            case EnemyController.deathType.normal:
                spr.sprite = normal;
                partRenderer.enabled = false;
                animatorComponent.SetBool("normal", true);
                break;

            case EnemyController.deathType.ice:
                spr.sprite = ice;
                partRenderer.material = iceMaterial;
                animatorComponent.SetBool("ice", true);
                break;

            case EnemyController.deathType.gaz:
               spr.sprite = gaz;
                partRenderer.material = gazMaterial;
                animatorComponent.SetBool("gaz", true);
                break;

            case EnemyController.deathType.electric:
                spr.sprite = electric;
                partRenderer.material = electricMaterial;
                animatorComponent.SetBool("electric", true);
                break;

            case EnemyController.deathType.fire:
                spr.sprite = fire;
                partRenderer.material = fireMaterial;
                animatorComponent.SetBool("fire", true);
                break;
        }

	}

    private void OrientTrail()
    {
        Vector3 vectorToTarget = frisbeeRigidbody.velocity;
        Debug.DrawLine(transform.position, transform.position + vectorToTarget);
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        trail.rotation = Quaternion.Slerp(trail.rotation, q, Time.deltaTime * 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            frisbeeRigidbody.velocity = new Vector2(-(frisbeeRigidbody.velocity.x), frisbeeRigidbody.velocity.y);

            OrientTrail();
        }
        else if (collision.tag == "Roof")
        {
            particleScript.Detatch();
            audioPlayer.PlaySound(FxPlayer.sounds.normalHit);
            Destroy(gameObject);
        }
        else if(collision.tag == "Enemy")
        {

            if (typeFrisbee != EnemyController.deathType.fire)
            {
                collision.gameObject.GetComponent<EnemyController>().DestroyBee(typeFrisbee);
                particleScript.Detatch();
                audioPlayer.PlaySound(FxPlayer.sounds.normalHit);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyController>().DestroyBee(typeFrisbee, collision.gameObject);
            }
        }
        else if (collision.tag == "Block")
        {
            collision.gameObject.GetComponent<Block>().LowerLife(5);
            audioPlayer.PlaySound(FxPlayer.sounds.normalHit);
            Destroy(gameObject);
        }
    }

}
