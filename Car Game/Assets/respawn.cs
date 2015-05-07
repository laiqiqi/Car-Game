using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {
	public string playerPrefabName = "Gun Car";
	public Transform [] spawnPoints;
	private Rigidbody rb;
	// Update is called once per frame
	void OnTriggerEnter(Collider collision) {
			int index = Random.Range (0, spawnPoints.Length);
			Debug.Log ("respawn");
			string s = collision.transform.parent.transform.parent.gameObject.name;
			int l = s.IndexOf("(");
			PhotonNetwork.Destroy(collision.transform.parent.transform.parent.gameObject);

			PhotonNetwork.Instantiate (s.Substring(0,l), spawnPoints [index].position, spawnPoints [index].rotation, 0);
	}	
}
