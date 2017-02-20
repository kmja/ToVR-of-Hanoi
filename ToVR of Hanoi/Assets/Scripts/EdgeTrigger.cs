﻿using UnityEngine;
using System.Collections;

public class edgeTrigger : MonoBehaviour {
	// Attached to box collider surrounding play area. If a disk leaves the area, bounce it back


	void OnTriggerExit(Collider other) {
		Debug.Log ("nu lämnade nåt");
		// If object exiting is not rubble, shoot it back
		if(other.gameObject.tag != "rubble") {
			// Placeholder: Drop the disk randomly on the table. Later, aim for the player's head
			Vector3 target = GameObject.Find("Middle").transform.position;
			float randRangeMin = -5f;
			float randRangeMax = 5f;
			other.gameObject.GetComponent<Rigidbody> ().MovePosition (new Vector3(Random.Range(randRangeMin, randRangeMax), 10f, Random.Range(randRangeMin, randRangeMax)));
		}
	}
}
