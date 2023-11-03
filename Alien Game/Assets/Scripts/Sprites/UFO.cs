using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private GameObject ufo;
    private float currentRotation = 0f;
    private float rotateSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        ufo = gameObject; // Assign the UFO game object to the 'ufo' variable.
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void getInput()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Rotate the UFO to the right
            currentRotation = Mathf.Clamp(currentRotation - rotateSpeed, -20f, 20f);
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation);
            ufo.transform.rotation = rotation;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Rotate the UFO to the left
            currentRotation = Mathf.Clamp(currentRotation + rotateSpeed, -20f, 20f);
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation);
            ufo.transform.rotation = rotation;
        }
    }
}
