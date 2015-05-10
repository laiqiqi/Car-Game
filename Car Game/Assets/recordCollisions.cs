using UnityEngine;
using System.Collections;

public class recordCollisions : MonoBehaviour {

	public Transform Bumper; 

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter (Collider collider){
		Bumper = collider.transform.root.transform;
	}

}
