using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour { 
	public float startTime; 
	private float restSeconds; 
	private int roundedRestSeconds; 
	private float displaySeconds; 
	private float displayMinutes; 
	public int CountDownSeconds=120; 
	private float Timeleft; 
	public GameObject textgameobject;
	public Canvas EndOfGameMenu;
	string timetext; 


	void Update() { 

		Timeleft= Time.time-Time.deltaTime; 
		restSeconds = CountDownSeconds-(Timeleft); 
		roundedRestSeconds=Mathf.CeilToInt(restSeconds); 
		if (roundedRestSeconds > 0){
		displaySeconds = roundedRestSeconds % 60; 
		displayMinutes = (roundedRestSeconds / 60)%60; 
		timetext = (displayMinutes.ToString()+":"); 
		if (displaySeconds > 9) { 
			timetext = timetext + displaySeconds.ToString(); 
		} else {
			timetext = timetext + "0" + displaySeconds.ToString(); 
		} 
		Text txt =  textgameobject.GetComponent<Text>();
		txt.text = timetext;
	}
		else{
			EndOfGameMenu.enabled = true;
		}
}
}
