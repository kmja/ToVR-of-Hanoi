using UnityEngine;
using System.Collections;

public class pillarTrigger : MonoBehaviour {

	public string tag;
	private GameObject disk;

	void OnTriggerEnter(Collider other) {
		// Instantiate parent, which all operations will be made on
		disk = other.transform.parent.gameObject;
		// Check if the move is valid. If not, shoot the disk upwards
		for (int i = System.Convert.ToInt32 (disk.name) - 1; i > 0; i--) {
			// Check if the lower numbered disks have the same tag (= they are already on the pillar)
			if (GameObject.Find (i.ToString()).tag == tag) {
				disk.GetComponent<Rigidbody> ().velocity = new Vector3(0f,10f,0f);
				Debug.Log ("break! " + disk.name);
				break;
			}
		}
		// Check if the disk is already tagged to prevent setting the same tags multiple times, then tag it
		if(disk.tag != tag) {
			disk.tag = tag;
		}

	}
}
