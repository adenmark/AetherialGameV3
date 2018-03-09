using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhaseScript : MonoBehaviour
{
    public float RotationAngle = 0;
    public float CrystalCount = 0;

    private float CrystalDeath = 0;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        RotateLeft();
        if (CrystalDeath == CrystalCount)
        {
            Destroy(gameObject);
        }
	}

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -RotationAngle);
    }

    public void CrytalDeath()
    {
        CrystalDeath++;
    }
}
