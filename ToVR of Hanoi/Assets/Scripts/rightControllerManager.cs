using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightControllerManager : MonoBehaviour {

	private Vector3 lastPos;
	private Vector3 lastRot;
	private float speed = 100f;
	private float rotLevel = 1f;
	private Vector3 offsetPos;
	private Quaternion offsetRot;
	private GameObject disk;
	private bool grabbed;

	public string controller;

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent.name == "Disks") {
			// On trigger down, save initial offset between controller and disk
			if (Input.GetButtonDown(controller)) {
				// Set "disk" to current disk
				disk = other.gameObject;
				// Turn off disk physics and set "grabbed"
				grabbed = true;
				setDiskPhysics(false);
				offsetPos = other.transform.position - transform.position;
				//offsetRot = other.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
			}

		}
	}

	void Update() {
		// While disk is grabbed, reset velocity
		if(grabbed){
			disk.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		// On trigger up, reset variables and disk physics
		if(Input.GetButtonUp(controller)){
			// Turn on disk physics and reset "grabbed"
			grabbed = false;
			setDiskPhysics(true);
			// Clear "disk" variable
			disk = null;
		}
		// While trigger down, move disk according to controller movement
		if (Input.GetButton (controller) && grabbed) {
			// Get disk position and rotation
			Vector3 diskPos = disk.transform.position;
			Vector3 diskRot = disk.transform.rotation.eulerAngles;
			// Calculate changes in controller position and rotation
			Vector3 deltaPos = transform.position - lastPos;
			Vector3 deltaRot = transform.rotation.eulerAngles - lastRot;
			// Apply changes to disk position and rotation
			float step = speed * Time.deltaTime;
			disk.gameObject.transform.position = Vector3.MoveTowards (diskPos, diskPos + deltaPos, step);
			disk.gameObject.transform.rotation = Quaternion.Euler(diskRot + deltaRot);
		}
		// Log previous positions of controllers, and while trigger is held, mirror disk movement to controller movement. Don't set disk position to controller position. Instead, track movements of controller while trigger is being held and move the disk accordingly.
		lastPos = transform.position;
		lastRot = transform.rotation.eulerAngles;
	}

	void setDiskPhysics(bool on){
		if (on) {
			disk.gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			disk.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		} else {
			disk.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
			disk.gameObject.GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
