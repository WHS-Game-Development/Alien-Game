using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

   [Header("TURRET SETTINGS")]
   //INSPECTABLE SETTINGS (Tweakable in Inspector)
   [SerializeField] private float projectileSpeed = 5.0f;
    private GameObject projectilePrefab;

	private Transform target;
	
	//private Rigidbody2D projectile;
	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start() {
		projectilePrefab = GameManager.Instance.currentWeaponPrefab;
	}
	
	// Update is called once per frame
	void Update () {
		rotateTurret();
		
		// if the user clicks the mouse, fire the turret
		if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isPaused)
			Fire();
	}
	
	private void Fire() {
		// get the correct weapon
		projectilePrefab = GameManager.Instance.currentWeaponPrefab;
		// Create the projectile
		GameObject projectileClone = Instantiate( projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
		
		// add velocity to the projectile
        projectileClone.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

		// Destroy the bullet after 3 seconds
		Destroy(projectileClone, 3.0f);
	}
	
	private void rotateTurret() {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, projectileSpeed * Time.deltaTime);
	}
	
	


}
