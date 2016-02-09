using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerUI : MonoBehaviour
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {

        [SerializeField] private string m_steeringInput = "WASD Steering";
        [SerializeField] private string m_accelInput = "WASD Acceleration";
        [SerializeField] private string m_brakeInput = "WASD Brake";

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis(m_steeringInput);
            float a = CrossPlatformInputManager.GetAxis(m_accelInput);
            float b = CrossPlatformInputManager.GetAxis(m_brakeInput);
            m_Car.Move(h, a, b);

        }
    }
}
