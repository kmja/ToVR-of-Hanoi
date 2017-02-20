using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftControllerManager : MonoBehaviour {

	private Vector3 lastPos;
	private Vector3 lastRot;
	private float step = 0.05f;

	void Update() {
		// Log previous positions of controllers, and while trigger is held, mirror disk movement to controller movement. Don't set disk position to controller position. Instead, track movements of controller while trigger is being held and move the disk accordingly.
		lastPos = transform.position;
		lastRot = transform.rotation.eulerAngles;
	}

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent.name == "Disks") {
			if (Input.GetButton ("Left Trigger")) {
				other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				other.gameObject.transform.position = Vector3.MoveTowards (other.gameObject.transform.position, transform.position, step);
				// Create vector of rotation change and rotate disk accordingly
				Vector3 rotChange = transform.rotation.eulerAngles - lastRot;
				other.gameObject.transform.Rotate (rotChange);
			}
		}
	}
}
