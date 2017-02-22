using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerManager : MonoBehaviour {

	private Vector3[] lastPosList = new Vector3[10];
	private Vector3[] lastRotList = new Vector3[10];
	private Vector3 deltaRot;
	public float moveSpeedPos = 100f;
	public float moveSpeedRot = 1000f;
	public float throwForce = 4000f;
	private GameObject disk;
	private bool grabbed;

	public string controller;

	void OnTriggerStay(Collider other) {
		// Lock position of disk to controller while their colliders are touching and the trigger is pressed
		if (other.transform.parent != null && other.transform.parent.name == "Disks") {
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
//
//	void Update() {
//		// While disk is grabbed, reset velocity
//		if(grabbed){
//			disk.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//		}
//		// On trigger up, reset variables and disk physics
//		if(Input.GetButtonUp(controller)){
//			if (grabbed) {
//				// Turn on disk physics and reset "grabbed"
//				grabbed = false;
//				setDiskPhysics(true);
//				// Push disk in the direction of last controller movement
//				disk.gameObject.GetComponent<Rigidbody>().AddForce(throwForce * (lastPosList[0] - lastPosList[9]));
//				// Give it angular momentum in the same way
//				disk.gameObject.GetComponent<Rigidbody>().angularVelocity = (lastRotList[0] - lastRotList[5]).normalized * 1f;
//				// Clear "disk" variable
//				disk = null;
//			}
//		}
//		// While trigger down, move disk according to controller movement
//		if (Input.GetButton (controller) && grabbed) {
//			// Get disk position
//			Vector3 diskPos = disk.transform.position;
//			// Calculate changes in controller position
//			Vector3 deltaPos = transform.position - lastPosList[0];
//			// Apply changes to disk position and rotation
//			float stepPos = moveSpeedPos * Time.deltaTime;
//			disk.gameObject.transform.position = Vector3.MoveTowards (diskPos, diskPos + deltaPos, stepPos);
//			float stepRot = moveSpeedRot * Time.deltaTime;
//			disk.transform.rotation = Quaternion.RotateTowards(disk.transform.rotation, transform.rotation, stepRot);
//		}
//		// Log previous positions and rotation of controller
//		lastPosList [0] = transform.position;
//		for (int i = 9; i > 0; i--) {
//			lastPosList [i] = lastPosList [i - 1];
//		}
//		lastRotList [0] = transform.rotation.eulerAngles;
//		for (int i = 9; i > 0; i--) {
//			lastRotList [i] = lastRotList [i - 1];
//		}
//
//	}

	void Update() {
		// When trigger is released, reset disk
		if(Input.GetButtonUp(controller)) {
			if (grabbed) {
				// Move disk back to "Disks" object
				disk.transform.parent = GameObject.Find("Disks").transform;
				// Turn on disk physics and reset "grabbed"
				grabbed = false;
				setDiskPhysics(true);
				// Push disk in the direction of last controller movement
				disk.gameObject.GetComponent<Rigidbody>().AddForce(throwForce * (lastPosList[0] - lastPosList[9]));
				// Give it angular momentum in the same way
				disk.gameObject.GetComponent<Rigidbody>().angularVelocity = (lastRotList[0] - lastRotList[5]).normalized * 1f;
				// Clear "disk" variable
				disk = null;
			}
		}
		// While trigger down and disk is on pillar, mirror controller movement
		if(Input.GetButton(controller) && grabbed) {
			if (disk.tag == "Untagged") {
				disk.gameObject.transform.position = transform.position;
				disk.gameObject.transform.rotation = transform.rotation;
			} else {
				// Get disk position
				Vector3 diskPos = disk.transform.position;
				// Calculate changes in controller position
				Vector3 deltaPos = transform.position - lastPosList[0];
				// Apply changes to disk position and rotation
				float stepPos = moveSpeedPos * Time.deltaTime;
				disk.gameObject.transform.position = Vector3.MoveTowards (diskPos, diskPos + deltaPos, stepPos);
			}
		}
		// Log previous positions and rotation of controller
		lastPosList [0] = transform.position;
		for (int i = 9; i > 0; i--) {
			lastPosList [i] = lastPosList [i - 1];
		}
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
