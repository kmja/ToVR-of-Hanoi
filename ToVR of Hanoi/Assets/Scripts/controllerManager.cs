using UnityEngine;
using System.Collections;

public class controllerManager : MonoBehaviour {
	
	void Update() {
		// Log something when each trigger is pressed 
		if(Input.GetButtonDown("14")) {
			Debug.Log ("Left trigger down");

		}
		if(Input.GetButtonDown("15")) {
			Debug.Log ("Right trigger down");

		}
		// Grab object

	}

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent.name == "Disks" && Input.GetButton("15")) {
			other.gameObject.transform.position = transform.position;
		}
	}

}

