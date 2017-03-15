using UnityEngine;
using System.Collections;

public class edgeTrigger : MonoBehaviour {
	// Attached to box collider surrounding play area. If a disk leaves the area, bounce it back


	void OnTriggerExit(Collider other) {
		// If object exiting is not rubble, shoot it back
		if(other.gameObject.tag != "rubble") {
			// Placeholder: Drop the disk randomly on the table. Later, aim for the player's head
			Vector3 target = GameObject.Find("Middle").transform.position;
			float randRangeMin = -1f;
			float randRangeMax = 1f;
			// Reset velocity and place disk
			other.transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			other.transform.position = new Vector3(Random.Range(randRangeMin, randRangeMax), 5f, Random.Range(randRangeMin, randRangeMax));
		}
	}
}
