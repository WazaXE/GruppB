using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    public DuckBoing[] duckBoings;


    [Header("Duck Specs")]
    public float pointBase; //In Meters
    public float rearTrack; //In Meters
    public float turnRadius; //In Meters
    private float rotation, rotateSpeed;
    public float Roll = 0.1125f;
    public Vector3 offset;

    //Inputs
    public float steerInput;

    public float ackermannAngleLeft;
    public float ackermannAngleRight;


    void Start()
    {
        rotateSpeed = 100f;
    }
    private void LateUpdate()
    {
        transform.Rotate(0f, rotation, 0f);

        if (Input.GetButtonDown("Jump"))
        {
            
        }

    }

    void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0)
        { //is turning right
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(pointBase / (turnRadius + (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(pointBase / (turnRadius - (rearTrack / 2))) * steerInput;

        }
        else if (steerInput < 0)
        { // is turning left
            ackermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(pointBase / (turnRadius - (rearTrack / 2))) * steerInput;
            ackermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(pointBase / (turnRadius + (rearTrack / 2))) * steerInput;

        }
        else
        {
            ackermannAngleLeft = 0;
            ackermannAngleRight = 0;
        }

        foreach (DuckBoing steerAngle in duckBoings)
        {
            if (steerAngle.PointL)
                steerAngle.steerAngle = ackermannAngleLeft;
            if (steerAngle.PointR)
                steerAngle.steerAngle = ackermannAngleRight;
        }
    }
}
