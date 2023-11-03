using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
	float cameraDistanceMax = 20f;
	float cameraSpeed = 5;
	float cameraDistanceMin = 5f;
	float cameraDistance = 10f;
	float scrollSpeed = 0.5f;
	
	private float minZoom = 2;
	private float maxZoom = 8;
	private float currentZoom = 5;
	private float minX, maxX, minY, maxY;
	
	private Vector3 touchStart;
	
	[SerializeField] private GameObject CameraBoundMins;
	[SerializeField] private GameObject CameraBoundMaxs;
	
	public GameObject ufoObject;
	
	// Use this for initialization
	void Start () {
		maxX = CameraBoundMaxs.transform.position.x;
		minX = CameraBoundMins.transform.position.x;
		maxY = CameraBoundMaxs.transform.position.y;
		minY = CameraBoundMins.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		getInput();
	}
	
	
	private void getInput() {
		// pc controls
		if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < maxX)
		{
			transform.Translate(new Vector3(cameraSpeed * Time.deltaTime,0,0));
		}
		if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > minX)
		{
			transform.Translate(new Vector3(-cameraSpeed * Time.deltaTime,0,0));
		}
		if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > minY)
		{
			transform.Translate(new Vector3(0,-cameraSpeed * Time.deltaTime,0));
		}
		if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < maxY)
		{
			transform.Translate(new Vector3(0,cameraSpeed * Time.deltaTime,0));
		}
		// drag pan
		if(Input.GetMouseButtonDown(0))
		{
			touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		
		if( Input.touchCount == 2 )
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
			
			float difference = currentMagnitude - prevMagnitude;
			
			zoom(difference * 0.01f);
		}
		
		else if(Input.GetMouseButton(0))
		{
			Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Camera.main.transform.position +=  direction;
		}
		
		zoom(Input.GetAxis("Mouse ScrollWheel"));

		

	}
	
	void zoom(float increment)
	{
		currentZoom = Mathf.Clamp(Camera.main.orthographicSize - increment, minZoom, maxZoom);
		Camera.main.orthographicSize = currentZoom;
	}
	
	 private void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
     {
         // Calculate how much we will have to move towards the zoomTowards position
         float multiplier = (1.0f / this.GetComponent<Camera>().orthographicSize * amount);
 
         // Move camera
         transform.position += (zoomTowards - transform.position) * multiplier; 
 
         // Zoom camera
         this.GetComponent<Camera>().orthographicSize -= amount;
 
         // Limit zoom
         this.GetComponent<Camera>().orthographicSize = Mathf.Clamp(this.GetComponent<Camera>().orthographicSize, minZoom, maxZoom);
     }

}
