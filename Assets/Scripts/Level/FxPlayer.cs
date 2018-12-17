using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxPlayer : MonoBehaviour {
    [SerializeField] private AudioClip ennemyShoot,
        electricHit, 
        electricShoot, 
        gazHit, 
        gazShoot, 
        fireHit, 
        fireShoot, 
        iceHit, 
        iceShoot, 
        normalHit, 
        normalShoot, 
        playerDying, 
        playerHit, 
        buyingShop,
        iceFroze;

    public enum sounds {
        enemyShoot,
        electricHit,
        electricShoot,
        gazHit,
        gazShoot,
        fireHit,
        fireShoot,
        iceHit,
        iceShoot,
        normalHit,
        normalShoot,
        playerDying,
        playerHit,
        buyingShop,
        iceFroze};

    private AudioSource audioSourceComponent;

    void Start () {
        audioSourceComponent = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(sounds soundToPlay)
    {         

        switch (soundToPlay)
        {
            case sounds.enemyShoot:
                audioSourceComponent.PlayOneShot(ennemyShoot);
                break;
            case sounds.electricHit:
                audioSourceComponent.PlayOneShot(electricHit);
                break;
            case sounds.electricShoot:
                audioSourceComponent.PlayOneShot(electricShoot);
                break;
            case sounds.gazHit:
                audioSourceComponent.PlayOneShot(gazHit);
                break;
            case sounds.gazShoot:
                audioSourceComponent.PlayOneShot(gazShoot);
                break;
            case sounds.fireHit:
                audioSourceComponent.PlayOneShot(fireHit);
                break;
            case sounds.fireShoot:
                audioSourceComponent.PlayOneShot(fireShoot);
                break;
            case sounds.iceHit:
                audioSourceComponent.PlayOneShot(iceHit);
                break;
            case sounds.iceShoot:
                audioSourceComponent.PlayOneShot(iceShoot);
                break;
            case sounds.normalShoot:
                audioSourceComponent.PlayOneShot(normalShoot);
                break;
            case sounds.normalHit:
                audioSourceComponent.PlayOneShot(normalHit);
                break;
            case sounds.playerDying:
                audioSourceComponent.PlayOneShot(playerDying);
                break;
            case sounds.playerHit:
                audioSourceComponent.PlayOneShot(playerHit);
                break;
            case sounds.buyingShop:
                audioSourceComponent.PlayOneShot(buyingShop);
                break;
            case sounds.iceFroze:
                audioSourceComponent.PlayOneShot(iceFroze);
                break;
        }
    }
}
