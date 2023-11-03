using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {
	// INSPECTABLE SETTINGS
	[SerializeField] private float velocity = -3f;
	
	
	// instance variables
	private Rigidbody2D rb2d; 
	
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(velocity,rb2d.velocity.y);	
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		// controls when the bug hits something and should turn around
		if (col.CompareTag ("Crate") || col.CompareTag ("Ground") || col.CompareTag ("Enemy") || col.CompareTag ("Player")) {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			velocity *= -1;
		}
	}
}
