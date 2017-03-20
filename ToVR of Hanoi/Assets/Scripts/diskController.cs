using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diskController : MonoBehaviour {

	public Material defaultMaterial;
	public Material highlightMaterial;
	public bool grabbed = false;

	// On trigger enter: if other is a vive controller, change material on disk
	void OnTriggerEnter(Collider other) {
		if (other.name == "ViveGrip Touch Sphere") {
			// Reset material on all disks
//			for(int i = 1; i <= 5; i++) {
//				GameObject.Find(i.ToString()).transform.FindChild("Torus").GetComponent<Renderer> ().material = defaultMaterial;
//			}
			// Set highlight material on triggered disk
			//transform.FindChild("Torus").GetComponent<Renderer> ().material = highlightMaterial;
		}
	}

	// If vive trigger pressed while OnTriggerStay: tag disk as "grabbed"
	void OnTriggerStay(Collider other) {
		if (other.name == "ViveGrip Touch Sphere" && Input.GetButtonDown("Left Trigger") || Input.GetButtonDown("Right Trigger")) {
			transform.tag = "grabbed";
		}
	}
		
	// On trigger exit: reset material
	void OnTriggerExit(Collider other) {
		if (other.name == "ViveGrip Touch Sphere") {
			//transform.FindChild("Torus").GetComponent<Renderer> ().material = defaultMaterial;
		}
	}

//	// When grabbed, set highlight material on disk
//	void ViveGripInteractionStart() {
//		Debug.Log ("START");
//		if (grabbed) {
//			return;
//		}
//		transform.FindChild("Torus").GetComponent<Renderer> ().material = highlightMaterial;
//		grabbed = true;
//	}
//
//	// When released, reset material
//	void ViveGripInteractionStop() {
//		Debug.Log ("STOP");
//		if (!grabbed) {
//			return;
//		}
//		transform.FindChild("Torus").GetComponent<Renderer> ().material = defaultMaterial;
//		grabbed = false;
//	}
}
