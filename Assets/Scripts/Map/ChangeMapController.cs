using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeMapController : MonoBehaviour {

	[SerializeField]
	private CameraController cameraController;

	[System.NonSerialized]
	private Transform enemyMapCenterTile;

	[System.NonSerialized]
	private Transform playerMapCenterTile;

	public enum MapUserType {
		ENEMY,
		PLAYER
	}

	public MapUserType mapUserType = MapUserType.PLAYER;
	void Start() {
		GetComponent<KeyboardInput>().ChangeMap += ChangeCameraToAnotherMap;
	}

	private void ChangeCameraToAnotherMap() {
		if(cameraController.cameraData.centerTile.transform.name == "PlayerMapCenterTile") {
			mapUserType = MapUserType.ENEMY;
			cameraController.cameraData.centerTile = enemyMapCenterTile;
		}
		else if(cameraController.cameraData.centerTile.transform.name == "EnemyMapCenterTile"){
			mapUserType = MapUserType.PLAYER;
			cameraController.cameraData.centerTile = playerMapCenterTile;
		}
		transform.position = cameraController.cameraData.centerTile.position + new Vector3(0, 4, 1);
	}

	public void SetPlayerCenterTile(Transform playerMapCenterTile) {
		this.playerMapCenterTile = playerMapCenterTile;
	}

	public void SetEnemyCenterTile(Transform enemyMapCenterTile) {
		this.enemyMapCenterTile = enemyMapCenterTile;
	}
}
