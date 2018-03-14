using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject NukeTarget;

    public GameObject ShieldExplosion;
    public GameObject AetherStar;

    public float health;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Damage()
    {
        --health;
        if(health <= 0)
        {
            Instantiate(ShieldExplosion, NukeTarget.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(AetherStar, NukeTarget.transform.position, Quaternion.identity);
    }
}
