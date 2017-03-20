using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calibrator : MonoBehaviour {

	public GameObject LC;
	public GameObject RC;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Test setOrigin
		if(Input.GetButtonDown("o")) {
			setOrigin ();
		}
		
	}

	// Calculate origin offset to camera
	public void setOrigin() {
		// Set origin to the point between the controllers, approximating the position of the chest when the user stands in a T-pose.
		transform.localPosition = (LC.transform.position - RC.transform.position) / 2 - transform.parent.transform.position;
		// Log origin position
		Debug.Log(transform.localPosition);
	}
}
