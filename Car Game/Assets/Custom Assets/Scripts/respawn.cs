using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class respawn : MonoBehaviour {
	public Transform [] spawnPoints;
	private Transform car;
	public Canvas ControlsMenu;
	public Canvas LoseMenu;
	public GameObject Entries;
	// Update is called once per frame
	void OnTriggerEnter(Collider collision) {
			int index = Random.Range (0, spawnPoints.Length);
			Entries.GetComponent<ScoreManager>().ChangeScore(collision.transform.root.transform.name,"Falls",1);
		if (collision.GetComponentInChildren<recordCollisions> ().Bumper) {
			Entries.GetComponent<ScoreManager> ().ChangeScore (collision.GetComponentInChildren<recordCollisions> ().Bumper.name, "Bumps", 1);
		}
		collision.transform.root.transform.position = spawnPoints [index].position;
			collision.transform.root.transform.rotation = spawnPoints [index].rotation;
			collision.transform.root.transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			
		}
}
