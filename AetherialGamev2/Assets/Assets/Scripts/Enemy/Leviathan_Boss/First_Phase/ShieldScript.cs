﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
