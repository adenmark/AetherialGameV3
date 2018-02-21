using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectilesScript : MonoBehaviour {

    public float timeToDestroy;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
