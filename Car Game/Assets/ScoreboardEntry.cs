using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreboardEntry : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	

		PhotonView myPhotonView = GetComponent<PhotonView> ();
		myPhotonView.RPC ("UpdateScoreBoard", PhotonTargets.AllBuffered, "ScoreManager");
	}
}
