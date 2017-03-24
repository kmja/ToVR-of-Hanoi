using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// When "c" key is pressed, calibrate approximate position of chest
		// OR MAYBE just do the calibration in the test scene
		if(Input.GetButtonDown("c")) {
			//setOrigin ();
		}
		// When "s" key is pressed, load test scene
		if(Input.GetButtonDown("s")) {
			SceneManager.LoadScene("vivegripTest");
		}
	}
}
