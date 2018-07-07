using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeMapController : MonoBehaviour {

	void Start() {
		GetComponent<KeyboardInput>().ChangeMap += ChangeCameraToAnotherMap;
	}

	private void ChangeCameraToAnotherMap() {
		if(FindObjectOfType<CameraController>().cameraData.centerTile.transform.name == "PlayerMapCenterTile") {
			FindObjectOfType<CameraController>().cameraData.centerTile = GameObject.Find("EnemyMapCenterTile").GetComponent<Transform>();
		}
		else if(FindObjectOfType<CameraController>().cameraData.centerTile.transform.name == "EnemyMapCenterTile"){
			FindObjectOfType<CameraController>().cameraData.centerTile = GameObject.Find("PlayerMapCenterTile").GetComponent<Transform>();
		}
		transform.position = FindObjectOfType<CameraController>().cameraData.centerTile.position + new Vector3(0, 4, 1);
	}
}
