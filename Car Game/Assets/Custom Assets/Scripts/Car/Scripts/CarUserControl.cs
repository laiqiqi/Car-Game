using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class CarUserControl : Photon.MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		public Vector3 eulerAngleVelocity;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
		if (GetComponent<PhotonView>().isMine){
				// pass the input to the car!
				float h = CrossPlatformInputManager.GetAxis ("Horizontal");
				float v = CrossPlatformInputManager.GetAxis ("Vertical");
#if !MOBILE_INPUT
				float handbrake = CrossPlatformInputManager.GetAxis ("Jump");
				m_Car.Move (h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
			if (Input.GetKey(KeyCode.E)) { 
				Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
				transform.GetComponent<Rigidbody>().MoveRotation(transform.GetComponent<Rigidbody>().rotation * deltaRotation);

			}
        
    }


}
}