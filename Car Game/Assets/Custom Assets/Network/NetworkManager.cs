using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NetworkManager : MonoBehaviour {
	const string VERSION = "v1.0";
	public string roomName = "CarGame";
	public string playerPrefabName = "";
	public string playerName = "";
	public Transform [] spawnPoints;
	public GameObject TimeLimit;
	public GameObject nameinput;
	ScoreManager scoremanager;
	// Use this for initialization
	
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions () { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
	}
	
	void OnJoinedRoom(){
		scoremanager = GameObject.FindObjectOfType<ScoreManager> ();
		int index = Random.Range( 0, spawnPoints.Length );
		PhotonNetwork.Instantiate (playerPrefabName, 
		                           spawnPoints[index].position,
		                           spawnPoints[index].rotation,
		                           0);

		InputField playername = nameinput.GetComponent<InputField>();
		scoremanager.SetScore (playername.text,"Bumps",0);
		scoremanager.SetScore (playername.text,"Falls",0);
		TimeLimit.active = true;
	}
	
	
	
}
