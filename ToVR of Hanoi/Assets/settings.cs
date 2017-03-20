using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour {

	public static Material defaultMat;
	public static Material glowMat;


	// Use this for initialization
	void Start () {

		defaultMat = Resources.Load ("default", typeof(Material)) as Material;
		glowMat = Resources.Load ("glow", typeof(Material)) as Material;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
