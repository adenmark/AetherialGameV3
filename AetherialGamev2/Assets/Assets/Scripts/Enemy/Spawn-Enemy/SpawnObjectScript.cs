using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour {

    public float health;

    public GameObject DamageParticle;
    public Transform particlePosition;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Damage()
    {
        health--;
        Instantiate(DamageParticle, particlePosition.position, particlePosition.rotation);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
