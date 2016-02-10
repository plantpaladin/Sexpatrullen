using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    //Create an array for the wheels where 0 is fron left 1 front right 2, rear left 3 rear right
    [SerializeField] private WheelCollider[] m_wheelColliders = new WheelCollider[4]; 
    //Set up other variables needed for driving
    [SerializeField] private Vector3 m_centerOfMassOffset;
    [SerializeField] private float m_maxSteerAngle = 25;
    [SerializeField] private float m_fullTorque = 2500;
    [SerializeField] private float m_reverseTorque = 500;
    [SerializeField] private float m_downForce = 100;
    [SerializeField] private float m_maxSpeed = 150;

    private float m_steerAngle;
    private float m_currentTorque;
    private Rigidbody m_rigidbody;


    private void Awake()
    {
        m_wheelColliders[0].attachedRigidbody.centerOfMass = m_centerOfMassOffset;
        m_rigidbody = GetComponent<Rigidbody>();
        m_currentTorque = m_fullTorque;
    }

    public void Move(float steering, float acceleration, float brake)
    {

        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            m_wheelColliders[i].GetWorldPose(out pos, out quat);
        }
        //Set the steering to the front wheels
        m_steerAngle = steering * m_maxSteerAngle;
        m_wheelColliders[0].steerAngle = m_steerAngle;
        m_wheelColliders[1].steerAngle = m_steerAngle;

        float speed = m_rigidbody.velocity.magnitude;
        if(speed > m_maxSpeed)
        {
            m_rigidbody.velocity = m_maxSpeed * m_rigidbody.velocity.normalized;
        }

        float thrustTorque;

        thrustTorque = acceleration * (m_currentTorque / 4f);
        for (int i = 0; i < 4; i++)
        {
            m_wheelColliders[i].motorTorque = thrustTorque;
        }

        m_wheelColliders[0].attachedRigidbody.AddForce(-transform.up * m_downForce * m_wheelColliders[0].attachedRigidbody.velocity.magnitude);
    }
}
