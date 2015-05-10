using UnityEngine;
using System.Collections;

public class Bomb : Projectile {
	
	protected override void Start () {
		initialVelocity = 5000;
		lifespan = 1;

		base.Start();
	}
}
