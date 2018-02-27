using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour {

    public GameObject DamageParticle;
    public Transform particlePosition;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnDestroy()
    {
        Instantiate(DamageParticle, particlePosition.position, particlePosition.rotation);
    }
}
