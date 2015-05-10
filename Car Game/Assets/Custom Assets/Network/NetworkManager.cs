using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NetworkManager : MonoBehaviour {
	const string VERSION = "v1.0";
	public string roomName = "CarGame";
	public string playerPrefabName = "";
	public string entryPrefabName = "Entry";
	public string scoreBoardPrefabName = "ScoreBoard";
	public string playerName = "";
	public Transform [] spawnPoints;
	public GameObject TimeLimit;
	ScoreManager scoremanager;
	private PhotonView MyPhotonView;
	menuScript MS;
	respawn Respawn;
	GameObject scoreBoard;

	// Use this for initialization
	
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions () { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
	}

	void OnCreatedRoom(){
		GameObject scoreBoard = (GameObject)PhotonNetwork.Instantiate (scoreBoardPrefabName,
		                                                    this.transform.position,
		                                                    Quaternion.identity,
		                                                    0);

	}

	void OnJoinedRoom(){
		scoremanager = GameObject.FindObjectOfType<ScoreManager> ();
		int index = Random.Range( 0, spawnPoints.Length );
		GameObject car = PhotonNetwork.Instantiate (playerPrefabName, 
		                           spawnPoints[index].position,
		                           spawnPoints[index].rotation,
		                           0);
		PhotonView carPhotonView = car.GetComponent<PhotonView> ();
		carPhotonView.RPC("ChangeCarName",PhotonTargets.AllBuffered,playerName);
	
		GameObject entries = GameObject.Find ("ScoreBoard(Clone)/Entries");

		Respawn = GameObject.FindObjectOfType<respawn> ();
		Respawn.Entries = entries;

		MS = GameObject.FindObjectOfType<menuScript>();
		MS.ScoreBoard = scoreBoard;

		GameObject entry = (GameObject)PhotonNetwork.Instantiate (entryPrefabName,
		                                                          this.transform.position,
		                                                          Quaternion.identity,
		                                                          0);

		PhotonView myPhotonView = entry.GetComponent<PhotonView> ();
		myPhotonView.RPC("GitParent",PhotonTargets.AllBuffered,playerName);
		return;

		TimeLimit.active = true;
	}

	
}
