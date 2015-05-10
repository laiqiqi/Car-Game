using UnityEngine;
using System.Collections;

public class Rocket : Projectile {
	
	protected override void Start () {
		initialVelocity = 2500;
		lifespan = 1;

		base.Start();
	}
}
