using UnityEngine;
using System.Collections;

public class Bullet : Projectile {

	protected override void Start () {
		initialVelocity = 1000;
		lifespan = 1;

		base.Start();
	}
}
