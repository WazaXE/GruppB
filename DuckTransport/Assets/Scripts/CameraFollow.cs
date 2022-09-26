using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.1125f;
    public float fadeSpeed;
    public float fadeTime;
    public Vector3 offset;

    void FixedUpdate()
    {

        Vector3 desiredPosition = transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;


        transform.LookAt(target);
    }


}
