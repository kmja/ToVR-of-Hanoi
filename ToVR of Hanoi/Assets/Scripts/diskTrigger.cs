using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PART OF CHILD'S PLAY BY RICKARD
public class diskTrigger : MonoBehaviour {

	private GameObject disk;

	// On trigger exit, make disk a child of controller
	void OnTriggerExit(Collider other) {
		// Execute if other is a pillar 
		if(other.tag == "pillarTrigger") {
			// Instantiate disk variable
			disk = transform.parent.gameObject;
			// Make disk a child of controller with active trigger
			if(Input.GetButton("Right Trigger")){
				disk.transform.parent = GameObject.Find ("Controller (right)").transform;
				//disk.transform.localPosition = Vector3.zero;
			}else if(Input.GetButton("Left Trigger")){
				transform.parent.transform.parent = GameObject.Find ("Controller (left)").transform;
				//disk.transform.localPosition = Vector3.zero;
			}

		}
	}
}
