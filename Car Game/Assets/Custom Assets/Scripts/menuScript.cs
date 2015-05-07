using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas startMenu;
	public Canvas inGameMenu;
	public Canvas controlsMenu;
	public Canvas chooseCarMenu;
	public GameObject Manager;
	private NetworkManager networkManager;

	// Use this for initialization
	void Start () {
		networkManager = Manager.GetComponent<NetworkManager> ();
		networkManager.enabled = false;

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		inGameMenu = inGameMenu.GetComponent<Canvas> ();

		quitMenu.enabled = false;
		inGameMenu.enabled = false;

		controlsMenu.enabled = false;
		chooseCarMenu.enabled = false;

	}
	public void FixedUpdate(){
		if (Input.GetKey(KeyCode.Escape)) { inGameMenu.enabled = true; }

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
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Gun Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;
	}
	public void ChooseBombCar(){
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Bomb Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;
	}
	public void ChooseRocketCar(){
		controlsMenu.enabled = true;
		chooseCarMenu.enabled = false;
		networkManager.playerPrefabName = "Rocket Car";
		PhotonNetwork.ConnectUsingSettings("v1.0");
		networkManager.enabled = true;
	}

	public void Play(){
		startMenu.enabled = false;
		quitMenu.enabled = false;
		chooseCarMenu.enabled = true;
	}

	public void ExitGame(){
		Debug.Log ("exited game");
		Application.Quit ();

	}
	
}
