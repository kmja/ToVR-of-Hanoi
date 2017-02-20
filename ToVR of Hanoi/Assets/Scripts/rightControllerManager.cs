using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightControllerManager : MonoBehaviour {

	private Vector3 lastPos;
	private Vector3 lastRot;
	private float moveStep = 0.01f;
	private float rotLevel = 1f;
	private Vector3 offsetPos;
	private Quaternion offsetRot;

	void Update() {
		// Log previous positions of controllers, and while trigger is held, mirror disk movement to controller movement. Don't set disk position to controller position. Instead, track movements of controller while trigger is being held and move the disk accordingly.
		lastPos = transform.position;
		lastRot = transform.rotation.eulerAngles;
	}

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent.name == "Disks") {
			// On trigger down, save initial offset between controller and disk
			if (Input.GetButtonDown("Right Trigger")) {
				offsetPos = other.transform.position - transform.position;
				offsetRot = other.transform.rotation - transform.rotation;

				other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				other.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
			}
			// While trigger down, adjust offset according to controller movement and rotation
			if (Input.GetButton ("Right Trigger")) {
				
				other.gameObject.transform.position = Vector3.MoveTowards (other.gameObject.transform.position, transform.position, moveStep);
				// Create vector of rotation change and rotate disk accordingly
				Vector3 rotChange = transform.rotation.eulerAngles - lastRot;
				//other.gameObject.transform.Rotate (rotChange * rotLevel);
				other.gameObject.transform.RotateAround(transform.position, rotChange.normalized, rotChange.magnitude);
			}
		}
	}
}
