using UnityEngine;
using System.Collections;

public class pillarTrigger : MonoBehaviour {

	public string tag;

	void OnTriggerEnter(Collider other) {
		// Tag other object (a disk) with the pillar
		other.gameObject.tag = tag;
		Debug.Log (tag);
	}
}
