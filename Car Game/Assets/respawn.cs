using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {
	public string playerPrefabName = "Gun Car";
	public Transform [] spawnPoints;
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		int index = Random.Range( 0, spawnPoints.Length);
		other.gameObject.transform.position = spawnPoints [index].position;
		Debug.Log ("respawn");
	}	
}
