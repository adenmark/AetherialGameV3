using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour {

    public Transform[] backgrounds;   //holdings all bacrounds
    //[SerializeField]
    private float[] parallaxScales;   //amount of movment of eatch layer
    public float smoothing;           //how smot the movment is

    //private Transform cam;  // for the second tutoriol
    //[SerializeField]
    private Vector3 previousCameraPosition;


    ////second tutorial----------------------------------------
    //void Awake()
    //{
    //    cam = Camera.main.transform;
    //}

    //void Start()
    //{
    //    //the previous frame had current frames camera position
    //    previousCameraPosition = cam.position;

    //    //asigning coresponding paraallaxScales
    //    parallaxScales = new float[backgrounds.Length];
    //    for (int i = 0; i < backgrounds.Length; i++)
    //    {
    //        parallaxScales[i] = backgrounds[i].position.z * -1;
    //    }
    //}

    //void Update()
    //{
    //    // for each bakground
    //  for (int i = 0; i < backgrounds.Length; i++)
    //    {
    //        //the parallax is the opposite of the camera movment because the previous frame multiplied by the scale
    //        float parallax = (previousCameraPosition.x - cam.position.x) * parallaxScales[i];

    //        // set a target x position which is the current position plus the parallax
    //        float backgroundTargetPosX = backgrounds[i].position.x + parallax;

    //        // set a target y position which is the current position plus the parallax
    //        //float backgroundTargetPosY = backgrounds[i].position.y + parallax;

    //        //create a target position which is the background current postion with it is target x position
    //        Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

    //        //fade between current position and the target position using lerp
    //        backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);



    //    }
    //  //set the privousCamPosition to the cameras position at the end of the frame
    //    previousCameraPosition = cam.position;


    //}



    //first tutorial-----------------------------------------
    // Use this for initialization
    //[SerializeField]
    void Start()
    {
        previousCameraPosition = transform.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    //[SerializeField]
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);   //how mutch movment need to hapen and smothing amount
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);   //adding to curent positions

        }
        previousCameraPosition = transform.position;

    }
    //--------------------------------------------------------------
}
