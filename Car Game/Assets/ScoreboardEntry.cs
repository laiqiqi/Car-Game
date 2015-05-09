using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardEntry : MonoBehaviour {
	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
		Debug.Log (scoreManager.name);
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreManager == null) {
			Debug.LogError ("You forgot to add the score manager component to a game object!");
			return;
			
		}

		while (this.transform.childCount > 0){
			Transform c = this.transform.GetChild (0);
			c.SetParent (null);
			Destroy (c.gameObject);

		}
		string[] names = scoreManager.GetPlayerNames ();
		foreach(string name in names) {

			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab,this.transform.position, Quaternion.identity);
			go.transform.SetParent (this.transform);
			go.transform.Find ("Username").GetComponent<Text>().text = name;
			go.transform.Find ("Bumps").GetComponent<Text>().text = scoreManager.GetScore (name,"Bumps").ToString();
			go.transform.Find ("Falls").GetComponent<Text>().text = scoreManager.GetScore (name,"Falls").ToString();

		}
	}
}
