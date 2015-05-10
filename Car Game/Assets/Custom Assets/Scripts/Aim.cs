using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	
	public Transform bodyToRotate;

	private float upperRotationLimit;
	private float lowerRotationLimit;

	// Use this for initialization
	void Start () {
		upperRotationLimit = 10;
		lowerRotationLimit = -30;
	}
	
	// Update is called once per frame
	void Update () {
		float percent = 1 - Mathf.Clamp((Input.mousePosition.y / Screen.height), 0, 1);
		float angle = lowerRotationLimit + ((upperRotationLimit - lowerRotationLimit) * percent);
		bodyToRotate.eulerAngles = new Vector3(angle, 0, 0);
	}
}
