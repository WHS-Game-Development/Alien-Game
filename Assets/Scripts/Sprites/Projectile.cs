using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		

		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Enemy")) {
			// kill the enemy
			Destroy (col.gameObject); 
			
			// kill the projectile
			Destroy(gameObject);
		}
		
		if (col.CompareTag ("Crate")) {

			// kill the projectile
			Destroy(gameObject,1.0f);
		}
	}
}
