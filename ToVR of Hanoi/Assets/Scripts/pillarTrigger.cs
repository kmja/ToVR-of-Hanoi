using UnityEngine;
using System.Collections;

public class pillarTrigger : MonoBehaviour {

	public string tag;
	private GameObject disk;
	private bool legalMove;

	// On trigger enter, check if move is legal. If so, tag disk with pillar tag
	void OnTriggerEnter(Collider other) {
		// Check if trigger is the child of a numbered gameobject (= a disk)
		int name;
		if (int.TryParse(other.transform.parent.name, out name)) {
			//Instantiate legalMove bool
			legalMove = true;
			// Instantiate parent, which all operations will be made on
			disk = other.transform.parent.gameObject;
			// Check if the move is valid. If not, shoot the disk upwards
			for (int i = System.Convert.ToInt32 (disk.name) - 1; i > 0; i--) {
				// Check if the lower numbered disks have the same tag (= they are already on the pillar)
				if (GameObject.Find (i.ToString()).tag == tag) {
					disk.GetComponent<Rigidbody> ().velocity = new Vector3(0f,10f,0f);
					Debug.Log ("break on disk: " + disk.name);
					legalMove = false;
					break;
				}
			}
			// Tag disk if it's not already tagged and the move is legal
			if(legalMove){
				disk.tag = tag;
			}
		}
	}

	// On trigger exit, remove tag from disk
	void OnTriggerExit(Collider other) {
		// Check if trigger is the child of a numbered gameobject (= a disk)
		int name;
		if (int.TryParse(other.transform.parent.name, out name)) {
			// Instantiate disk object and remove tag
			disk = other.transform.parent.gameObject;
			disk.tag = "Untagged";
		}
	}
}
