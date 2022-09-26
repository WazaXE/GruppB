using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBoing : MonoBehaviour
{
    private Rigidbody rb;

    public bool PointR;
    public bool PointL;
    public bool PointBR;
    public bool PointBL;

    


    [Header("Suspention")]
    public float restLength;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;

    private float minLength;
    private float maxLength;
    private float springLength;
    private float springForce;
    private float lastLength;
    private float damperForce;
    private float springVelocity;

    public float steerAngle;

    private Vector3 suspensionForce;
    private Vector3 boingVelocityLS; //local space
    private float Fx;
    private float Fy;

    [Header("Boing")]
    public float boingRadius;
    

    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody>();

        minLength = restLength - springTravel;
        maxLength = restLength + springTravel;   

    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + steerAngle, transform.localRotation.z);
    
        Debug.DrawRay(transform.position, -transform.up * (springLength + boingRadius), Color.green); // to visualize the points remove when done

    }

    

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + boingRadius)) {
            springTravel = hit.distance - boingRadius;
            
            lastLength = springLength;
            springVelocity = (lastLength - springLength) / Time.deltaTime;
            damperForce = damperStiffness = springVelocity;
            springLength = Mathf.Clamp(springLength, minLength, maxLength);

            springForce = springStiffness * (restLength - springLength);

            suspensionForce = (springForce + damperForce) * transform.up;

            boingVelocityLS = transform.InverseTransformDirection(rb.GetPointVelocity(hit.point));
            Fx = Input.GetAxis("Vertical") * springForce;
            Fy = boingVelocityLS.x * springForce;

            rb.AddForceAtPosition(suspensionForce +  (Fx * transform.forward) + (Fy * -transform.right), hit.point);
        }
    }
}
