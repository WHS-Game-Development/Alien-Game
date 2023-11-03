using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
	private GameObject ufo;
	private float currentRotation = 0f;
	private float rotateSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
	}
	
	private void getInput(){
		
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			// rotate the ufo
			currentRotation = gameObject.transform.rotation.eulerAngles.z;   
			if ( currentRotation <= 20)  
			{
				currentRotation = 20f;
			}
			Quaternion rotation = Quaternion.Euler (0, 0, currentRotation - rotateSpeed);
                     //Move object to new rotation
            gameObject.transform.rotation = rotation;
			
		}
		
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
						// rotate the ufo
			currentRotation = gameObject.transform.rotation.eulerAngles.z;   
			if ( currentRotation < 180 && currentRotation > 90)  
			{
				currentRotation = 120f;
			}
			Quaternion rotation = Quaternion.Euler (0, 0, currentRotation + rotateSpeed);
                     //Move object to new rotation
            gameObject.transform.rotation = rotation;
		}
	}
}
