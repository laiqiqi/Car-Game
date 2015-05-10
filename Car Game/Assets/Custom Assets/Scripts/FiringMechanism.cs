using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FiringMechanism : MonoBehaviour {
	
	public Transform projectileSpawnPosition;
	public GameObject projectileToFire;
	public float reloadsPerSecond;
	public int maxRoundsChambered;

	private int roundsChambered;
	private float lastReloadTime;
	private float reloadRate;
	
	void Start () {
		roundsChambered = maxRoundsChambered;
		lastReloadTime = Time.time;
	}

	void Update () {
		InitializeReloadRate();
		ChamberNewRounds ();

		if (Input.GetMouseButtonDown(0)) {
			if (roundsChambered > 0) {
				print (reloadRate);
				FireProjectile();
			}
		}
	}

	void ChamberNewRounds () {
		if (roundsChambered < maxRoundsChambered) {
			if (Time.time - lastReloadTime > reloadRate) {
				roundsChambered ++;
				lastReloadTime = Time.time;
				print (roundsChambered);
			}
		}
	}

	void InitializeReloadRate () {
		reloadRate = 1F / reloadsPerSecond;
	}

	void FireProjectile () {
		//Instantiate (projectileToFire, projectileSpawnPosition.position, Quaternion.identity);
		roundsChambered --;
		print (roundsChambered + "fire");
	}
}
