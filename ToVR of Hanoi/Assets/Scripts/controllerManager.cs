using UnityEngine;
using System.Collections;

public class controllerManager : MonoBehaviour {

	private GameObject left;
	private GameObject right;
	private Vector3 lastPos;
	private Vector3 lastRot;
	private float step = 0.05f;

	void Start() {
		left = GameObject.Find ("Controller (left)");
		right = GameObject.Find ("Controller (right)");
	}

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
				//other.gameObject.transform.position = left.transform.position;
				other.gameObject.transform.position = Vector3.MoveTowards (other.gameObject.transform.position, GameObject.Find ("Controller (left)").transform.position, step);
				other.gameObject.transform.rotation = left.transform.rotation;
			} else if (Input.GetButton ("Right Trigger")) {
				other.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				//other.gameObject.transform.position = right.transform.position;
				other.gameObject.transform.position = Vector3.MoveTowards (other.gameObject.transform.position, GameObject.Find ("Controller (right)").transform.position, step);
				other.gameObject.transform.rotation = right.transform.rotation;
			}
		}

	}

}

