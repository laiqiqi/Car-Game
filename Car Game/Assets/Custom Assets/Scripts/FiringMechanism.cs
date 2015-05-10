using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FiringMechanism : MonoBehaviour {
	
	public List<Transform> projectileSpawnPositions = new List<Transform>();
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
				FireProjectile(projectileSpawnPositions[0]);
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

	void FireProjectile (Transform spawnPosition) {
		Instantiate (projectileToFire, spawnPosition.position, spawnPosition.rotation);
		roundsChambered --;
		print (roundsChambered + "fire");
	}
}
