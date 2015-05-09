using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	Dictionary<string,Dictionary<string,int>> playerScores;


	// Use this for initialization
	void Start () {
		}

	void Init(){
		if (playerScores != null) {
			return;
		}
		playerScores = new Dictionary<string, Dictionary<string,int>> ();
	}

	public int GetScore(string username, string scoreType){
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			return 0;
		}

		if (playerScores [username].ContainsKey (scoreType) == false) {
			return 0;
		}

		return playerScores [username] [scoreType];
	}

	public void SetScore(string username, string scoreType, int value){
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			playerScores[username] = new Dictionary<string,int>();
		}
		playerScores [username] [scoreType] = value;
	}

	public void ChangeScore(string username, string scoreType, int amount){
		Init ();
		int currScore = GetScore (username, scoreType);
		SetScore (username, scoreType, currScore + amount);

	}

	public string[] GetPlayerNames(){
		Init ();
		return playerScores.Keys.ToArray();

	}

	// Update is called once per frame
	void Update () {
	
	}
}
