using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;

[RequireComponent(typeof(CameraData))]
public class CameraController : MonoBehaviour {

    private float zoom = 1f;
    private Quaternion swivel;
    private Vector3 stick;

    [SerializeField]
    public CameraData cameraData;

    void Awake() {
        swivel = transform.rotation;
		stick = transform.position;
        FindObjectOfType<MapGenerator>().MapsGenerated += GetInfoFromMap;
    }

    void Start () {
        transform.position = cameraData.centerTile.position + new Vector3(0, 4, 1);
	}

    void Update() {
        float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
		if (zoomDelta != 0f) {
			AdjustZoom(zoomDelta);
		}

        float xDelta = Input.GetAxis("Horizontal");
		float zDelta = Input.GetAxis("Vertical");
		if (xDelta != 0f || zDelta != 0f) {
			AdjustPosition(xDelta, zDelta);
		}
    }

    void GetInfoFromMap() {
        cameraData.focusedMap = GameObject.Find("PlayerMap");
        cameraData.centerTile = GameObject.Find("PlayerMapCenterTile").GetComponent<Transform>();
    }

    bool ReachedHorizontalBorders(Vector3 position) {
        if(position.z > cameraData.centerTile.position.z + 2f || position.z < cameraData.centerTile.position.z - 6f) {
            if(position.x > cameraData.centerTile.position.x + 5f || position.x < cameraData.centerTile.position.x - 7.6f) {
                return true;
            }
            return true;
        }
        return false;
    }

    bool ReachedVertcialBoders(Vector3 position) {
        if(position.x > cameraData.centerTile.position.x + 5f || position.x < cameraData.centerTile.position.x - 7.6f) {
               if(position.z > cameraData.centerTile.position.z + 2f || position.z < cameraData.centerTile.position.z - 6f) {
                   return true;
               }
               return true;
        }
        return false;
    }
    void AdjustZoom (float delta) {
		zoom = Mathf.Clamp01(zoom + delta);

		float distance = Mathf.Lerp(cameraData.StickMinZoom, cameraData.StickMaxZoom, zoom);
		stick = new Vector3(transform.position.x, distance, transform.position.z);
        transform.position = stick;

		float angle = Mathf.Lerp(cameraData.SwivelMinZoom, cameraData.SwivelMaxZoom, zoom);
		swivel = Quaternion.Euler(angle, transform.rotation.y, transform.rotation.z);
        transform.rotation = swivel;
	}

    void AdjustPosition (float xDelta, float zDelta) {
		Vector3 direction = new Vector3(xDelta, 0f, zDelta).normalized;
		float distance = 2f * Time.deltaTime;

		Vector3 position = transform.localPosition;
		position += direction * distance;
        if(!ReachedHorizontalBorders(position) && !ReachedVertcialBoders(position)) {
		    transform.localPosition = position;
        }
	}

}
