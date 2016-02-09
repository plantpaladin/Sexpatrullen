using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    [SerializeField] private float m_currentSpeed = 0f;
    [SerializeField] private float m_tourque = 50f;
    [SerializeField] private float m_maxSpeed = 200f;
    [SerializeField] private float m_brakeSpeed = 0f;
    [SerializeField] private float m_maxSteer = 25f;
    private Rigidbody m_rigidbody;


    void Awake()
    {
        m_rigidbody =  this.GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start ()
    {
        m_rigidbody.centerOfMass = new Vector3(0f, -0.5f, 0.3f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Move(float steering, float accel, float brake)
    {
        m_currentSpeed = (m_currentSpeed + 1) * 0.5f;
        m_currentSpeed = m_currentSpeed * m_tourque * Time.deltaTime * 100f;
        // Keep writing code here

    }
}
