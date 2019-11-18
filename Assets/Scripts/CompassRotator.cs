using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotator : MonoBehaviour {

    [SerializeField]
    private TurnModuleSystem turnModuleSystem;

	[Range(5, 15)]
	public float roationSpeed = 10f;

	private void Awake () {
		transform.rotation = Quaternion.identity;		
	}
	
	private void Update () {
		transform.RotateAround(transform.position, Vector3.back, roationSpeed * Time.deltaTime);
        if(transform.rotation.z % 360 == 0)
        {
            turnModuleSystem.EndTurn();
        }
	}
}
