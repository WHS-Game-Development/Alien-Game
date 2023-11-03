using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Projectile") ) {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			//velocity *= -1;
		}
	}
}
