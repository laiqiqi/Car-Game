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
	respawn Respawn;
	GameObject scoreBoard;
	public GameObject StartMenu;
	// Use this for initialization
	
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions () { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
	}

	void OnCreatedRoom(){
		// when we create the room, instantiate a scoreboard. 
		GameObject scoreBoard = (GameObject)PhotonNetwork.Instantiate (scoreBoardPrefabName,
		                                                    this.transform.position,
		                                                    Quaternion.identity,
		                                                    0);
		//attach scoreboard to menu script 
		
		StartMenu.GetComponent<menuScript> ().ScoreBoard = scoreBoard;

	}

	void OnJoinedRoom(){
		// when someone joins the room...




		// identify the ScoreManager script and the Entries gameobject in the ScoreBoard
		scoremanager = GameObject.FindObjectOfType<ScoreManager> ();
		GameObject entries = GameObject.Find ("ScoreBoard(Clone)/Entries");

		//attach entries object to respawn script
		Respawn = GameObject.FindObjectOfType<respawn> ();
		Respawn.Entries = entries;


		// spawn the car at some random spawnpoint and change its name to the player's name
		int index = Random.Range( 0, spawnPoints.Length );
		GameObject car = PhotonNetwork.Instantiate (playerPrefabName, 
		                           spawnPoints[index].position,
		                           spawnPoints[index].rotation,
		                           0);
		car.name = playerName;


		// instantiate an entry in the scoreboard and move it to the child of Entries, naming it the player's name
		GameObject entry = PhotonNetwork.Instantiate (entryPrefabName,
		                                                        	 Vector3.zero,
		                                                          Quaternion.identity,
		                                                          0);
		scoremanager.SetScore (playerName, "Falls", 0);
		scoremanager.SetScore(playerName, "Bumps", 0);
		Debug.Log (scoremanager.GetScore(playerName, "Bumps"));
		entry.transform.SetParent(entries.transform);

		entry.name = playerName;
		entry.transform.FindChild ("Username").GetComponent<Text> ().text = playerName;
		entry.transform.FindChild ("Bumps").GetComponent<Text> ().text = "0";
		entry.transform.FindChild ("Falls").GetComponent<Text> ().text = "0";



	

		//activate the timer
		TimeLimit.active = true;
	}

	
}
