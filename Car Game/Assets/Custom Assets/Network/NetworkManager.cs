using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string VERSION = "v1.0";
	public string roomName = "CarGame";
	public string playerPrefabName = "Gun Car";
	public Transform [] spawnPoints;
	
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings(VERSION);
		
		
	}
	
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions () { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
	}
	
	void OnJoinedRoom(){
		int index = Random.Range( 0, spawnPoints.Length );
		PhotonNetwork.Instantiate (playerPrefabName, 
		                           spawnPoints[index].position,
		                           spawnPoints[index].rotation,
		                           0);
		
	}
	
	
	
}
