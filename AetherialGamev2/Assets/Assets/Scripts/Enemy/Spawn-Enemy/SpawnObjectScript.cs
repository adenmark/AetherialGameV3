using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour {

    public GameObject DamageParticle;
    public Transform particlePosition;
    public GameObject aetherPickup;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Instantiate(DamageParticle, position: particlePosition.position, rotation: particlePosition.rotation);
        }
    }

    void OnDestroy()
    {
        Instantiate(DamageParticle, particlePosition.position, particlePosition.rotation);
        Instantiate(aetherPickup, transform.position, Quaternion.identity);
    }
}
