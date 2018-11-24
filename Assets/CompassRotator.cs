using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.identity;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.back, 10f * Time.deltaTime);
	}
}
