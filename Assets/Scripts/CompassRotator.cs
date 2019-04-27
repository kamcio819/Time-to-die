using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotator : MonoBehaviour {


	[Range(5, 15)]
	public float roationSpeed = 10f;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.identity;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.back, roationSpeed * Time.deltaTime);
	}
}
