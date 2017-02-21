using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerManager : MonoBehaviour {

	private Vector3[] lastPosList = new Vector3[10];
	private Vector3 lastRot;
	private Vector3 deltaPos;
	private Vector3 deltaRot;
	public float followSpeed = 100f;
	public float throwForce = 100f;
	private GameObject disk;
	private bool grabbed;

	public string controller;

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent != null && other.transform.parent.name == "Disks2.0") {
			// On trigger down, save initial offset between controller and disk
			if (Input.GetButtonDown(controller)) {
				if (!grabbed) {
					// Set "disk" to current disk
					disk = other.gameObject;
					// Turn off disk physics and set "grabbed"
					grabbed = true;
					setDiskPhysics(false);
				}
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
			if (grabbed) {
				// Turn on disk physics and reset "grabbed"
				grabbed = false;
				setDiskPhysics(true);
				// Push disk in the direction of last controller movement
				disk.gameObject.GetComponent<Rigidbody>().AddForce(throwForce * (lastPosList[0] - lastPosList[9]));
				// Clear "disk" variable
				disk = null;
			}
		}
		// While trigger down, move disk according to controller movement
		if (Input.GetButton (controller) && grabbed) {
			// Get disk position and rotation
			Vector3 diskPos = disk.transform.position;
			Vector3 diskRot = disk.transform.rotation.eulerAngles;
			// Calculate changes in controller position and rotation
			deltaPos = transform.position - lastPosList[0];
			deltaRot = transform.rotation.eulerAngles - lastRot;
			// Apply changes to disk position and rotation
			float step = followSpeed * Time.deltaTime;
			disk.gameObject.transform.position = Vector3.MoveTowards (diskPos, diskPos + deltaPos, step);
			//disk.gameObject.transform.Rotate(new Vector3(deltaRot.x, diskRot.y, diskRot.z));
			disk.gameObject.transform.Rotate(deltaRot);
		}
		// Log previous positions and rotation of controller
		lastPosList [0] = transform.position;
		for (int i = 9; i > 0; i--) {
			lastPosList [i] = lastPosList [i - 1];
		}
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
