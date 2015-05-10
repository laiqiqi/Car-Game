using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	protected float initialVelocity;
	protected float startTime;
	protected float lifespan;

	protected virtual void Start () {
		startTime = Time.time;
		Move ();
	}

	void Update () {
		Countdown();
	}

	private void Countdown () {
		if (Time.time - startTime > lifespan) {
			Destroy(gameObject);
		}
	}

	private void Move () {
		GetComponent<Rigidbody>().AddForce(Vector3.forward * initialVelocity);
	}
}
