using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas startMenu;
	public Canvas inGameMenu;
	public Canvas controlsMenu;
	public Canvas chooseCarMenu;
	public Canvas EndOfGameMenu;
	public Canvas PlayerNameMenu;
	public GameObject Manager;
	public Canvas ScoreBoard;
	private NetworkManager networkManager;
	public GameObject TimeLimit; 
	private InputField nameInputField = null;
	// Use this for initialization
	void Start () {
		networkManager = Manager.GetComponent<NetworkManager> ();
		networkManager.enabled = false;

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		inGameMenu = inGameMenu.GetComponent<Canvas> ();

		quitMenu.enabled = false;
		inGameMenu.enabled = false;
		EndOfGameMenu.enabled = false;
		controlsMenu.enabled = false;
		chooseCarMenu.enabled = false;
		ScoreBoard.enabled = false;
		PlayerNameMenu.enabled = false;
		TimeLimit.active = false;
	}
	public void Update(){
		if (Input.GetKey(KeyCode.Escape)) { inGameMenu.enabled = true; }
		if (Input.GetKeyDown(KeyCode.Tab)) {ScoreBoard.enabled = true;}
		if (Input.GetKeyUp(KeyCode.Tab)) {ScoreBoard.enabled = false;}
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		startMenu.enabled = false;
	}
	public void ContinuePress(){
		inGameMenu.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startMenu.enabled = true;
	}
	
	public void ChooseGunCar(){
		EndOfGameMenu.enabled = false;
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Gun Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;

	}
	public void ChooseBombCar(){
		EndOfGameMenu.enabled = false;
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Bomb Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;

	}
	public void ChooseRocketCar(){
		EndOfGameMenu.enabled = false;
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Rocket Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;

	}

	public void Play(){
		EndOfGameMenu.enabled = false;
		startMenu.enabled = false;
		quitMenu.enabled = false;
		PlayerNameMenu.enabled = true;

	}

	public void ChooseName(){
			PlayerNameMenu.enabled = false;
			quitMenu.enabled = false;
			EndOfGameMenu.enabled = false;
			chooseCarMenu.enabled = true;
	}

	public void ExitGame(){
		Debug.Log ("exited game");
		Application.Quit ();

	}



}
