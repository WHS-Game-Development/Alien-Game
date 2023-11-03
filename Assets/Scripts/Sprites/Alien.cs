using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
	// INSPECTABLE SETTINGS
	[SerializeField] private float velocity = 2f;
	
	
	// instance variables
	private Rigidbody2D rb2d; 
	
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// makes the alien move
		rb2d.velocity = new Vector2(velocity,rb2d.velocity.y);	
		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Crate") ) {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			velocity *= -1;
		}
		else if (col.CompareTag ("Acid") ) {
			rb2d.gravityScale=0.2f;
		}
	}
	
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Acid") ) {
			rb2d.gravityScale=1f;
		}
	}
}
