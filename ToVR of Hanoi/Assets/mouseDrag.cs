using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	public float distance;

	void OnMouseDrag() {
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPos = Camera.main.ScreenToWorldPoint (mousePos);

		transform.position = objPos;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
