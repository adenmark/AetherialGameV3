using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float Health;

    public void Damage()
    {
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
