using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    private CarController m_Car; // the car controller we want to use
 
    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }


    private void FixedUpdate()
    {
       
        float h = CrossPlatformInputManager.GetAxis("WASD Horizontal");
        float v = CrossPlatformInputManager.GetAxis("WASD Vertical");
        m_Car.Move(h, v, v, 0f);
    }
}
    