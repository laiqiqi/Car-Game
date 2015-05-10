using UnityEngine;
using System.Collections;

public class FiringMechanism : MonoBehaviour {

	public Transform projectileSpawnPosition;
	public GameObject projectileToFire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			FireProjectile();
		}
	}

	void FireProjectile () {
		Instantiate (projectileToFire, projectileSpawnPosition.position, Quaternion.identity);
	}
}
