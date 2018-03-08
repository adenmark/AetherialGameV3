using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhaseScript : MonoBehaviour
{
    public float RotationAngle = 0;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        RotateLeft();
	}

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -RotationAngle);
    }
}
