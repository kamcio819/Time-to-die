using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;

public class CameraController : MonoBehaviour {

    [SerializeField]
    [Tooltip("GameObject to keep offset from.")]
    private GameObject tileMap;
    public Vector3 CameraOffset { get; set; }

    //To manipulate through Inspector only
    #region Init Values of Camera
    [SerializeField]
    private float InitOffsetY;

    [SerializeField]
    private float stickMinZoom;

    [SerializeField]
    private float stickMaxZoom;

    [SerializeField]
    private float swivelMinZoom;

    [SerializeField]
    private float swivelMaxZoom;
    #endregion

    private Camera SelfCamera;
    private float zoom = 1f;
    private Quaternion swivel;
    private Vector3 stick;

    void Awake() {
        swivel = transform.rotation;
		stick = transform.position;
    }
    void Start () {
        SelfCamera = GetComponent<Camera>();
        // CameraOffset = new Vector3(tileMap.transform.position.x + 12.5f, InitOffsetY, tileMap.transform.position.z + 1f);
        // if (tileMap != null)
        //     transform.position = tileMap.transform.position + CameraOffset;
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

    bool ReachedHorizontalBorders(Vector3 position) {
        if(position.z > 6f || position.z < -2f) {
            if(position.x > 11.5f || position.x < -0.5f) {
                Debug.Log(1);
                return true;
            }
            Debug.Log(2);
            return true;
        }
        return false;
    }

    bool ReachedVertcialBoders(Vector3 position) {
        if(position.x > 11.5f || position.x < -0.5f) {
               if(position.z > 6f || position.z < -2f) {
                   Debug.Log(3);
                   return true;
               }
               Debug.Log(4);
               return true;
        }
        return false;
    }
    void AdjustZoom (float delta) {
		zoom = Mathf.Clamp01(zoom + delta);

		float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
		stick = new Vector3(transform.position.x, distance, transform.position.z);
        transform.position = stick;

		float angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
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
