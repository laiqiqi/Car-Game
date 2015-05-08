using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class respawn : MonoBehaviour {
	public Transform [] spawnPoints;
	private Transform car;
	public Canvas ControlsMenu;
	public Canvas LoseMenu;
	// Update is called once per frame
	void OnTriggerEnter(Collider collision) {
			int index = Random.Range (0, spawnPoints.Length);
			Debug.Log ("respawn");
			collision.transform.root.transform.position = spawnPoints [index].position;
			collision.transform.root.transform.rotation = spawnPoints [index].rotation;
			collision.transform.root.transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			if (ControlsMenu.transform.FindChild ("Life3").gameObject.active) {
			ControlsMenu.transform.FindChild ("Life3").gameObject.active = false;
			return;
		}
		else {
			if (ControlsMenu.transform.FindChild ("Life2").gameObject.active) {
				ControlsMenu.transform.FindChild ("Life2").gameObject.active = false;
				return;
			}
		
		else{
			ControlsMenu.transform.FindChild ("Life1").gameObject.active = false;
			return;

		}

		}
			}
	
}
