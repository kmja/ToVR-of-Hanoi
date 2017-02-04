using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	public float distance;

	void OnMouseDrag() {
		// Shoot ray to mouse position and set object position to that. Also reset velocity etc
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPos = Camera.main.ScreenToWorldPoint (mousePos);

		transform.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
		transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
		transform.position = objPos;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
