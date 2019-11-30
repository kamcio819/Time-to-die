using DG.Tweening;
using MapSystem;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    public CameraData cameraData = default;

    [Space(20)]
    [SerializeField]
    private KeyboardInput keyboardInput = default;

    [SerializeField]
    private CursorInput cursorInput = default;

    [SerializeField]
    private MapData mapData = default;

    [SerializeField]
    private MapModuleSystem mapGenerator = default;

    [SerializeField]
    [Range(10f, 13f)]
    private float rightCameraMovementOffset = 12f;

    [SerializeField]
    [Range(10f, 13f)]
    private float leftCameraMovementOffset = 10f;

    private float zoom = 1f;
    private Quaternion swivel;
    private Vector3 stick;

    private void Awake()
    {
        swivel = transform.rotation;
        stick = transform.position;
    }

    private void OnEnable()
    {
        mapGenerator.MapsGenerated += GetInfoFromMap;
    }

    private void OnDisable()
    {
        mapGenerator.MapsGenerated -= GetInfoFromMap;
    }

    private void Start()
    {
        transform.position = cameraData.centerTile.position + new Vector3(0, 4, 1);
    }

    private void Update()
    {
        if (keyboardInput.ZoomDelta != 0f)
        {
            AdjustZoom(keyboardInput.ZoomDelta);
        }
        if (keyboardInput.XDelta != 0f || keyboardInput.ZDelta != 0f)
        {
            AdjustPosition(keyboardInput.XDelta, keyboardInput.ZDelta);
        }
        if(cursorInput.XEdgeScreen != 0f || cursorInput.YEdgeScreen != 0f)
        {
            AdjustPosition(cursorInput.XEdgeScreen, cursorInput.YEdgeScreen);
        }
    }

    private void GetInfoFromMap()
    {
        cameraData.focusedMap = mapGenerator.MapObject;
        cameraData.centerTile = mapGenerator.CenterTile;
    }

    private bool ReachedHorizontalBorders(Vector3 position)
    {
        if (position.z > cameraData.centerTile.position.z + leftCameraMovementOffset || position.z < cameraData.centerTile.position.z - rightCameraMovementOffset)
        {
            if (position.x > cameraData.centerTile.position.x + leftCameraMovementOffset || position.x < cameraData.centerTile.position.x - rightCameraMovementOffset)
            {
                return true;
            }
            return true;
        }
        return false;
    }

    private bool ReachedVertcialBoders(Vector3 position)
    {
        if (position.x > cameraData.centerTile.position.x + leftCameraMovementOffset || position.x < cameraData.centerTile.position.x - rightCameraMovementOffset)
        {
            if (position.z > cameraData.centerTile.position.z + leftCameraMovementOffset || position.z < cameraData.centerTile.position.z - rightCameraMovementOffset)
            {
                return true;
            }
            return true;
        }
        return false;
    }

    private void AdjustZoom(float delta)
    {
        zoom = Mathf.Clamp01(zoom + delta);

        float distance = Mathf.Lerp(cameraData.StickMinZoom, cameraData.StickMaxZoom, zoom);
        stick = new Vector3(transform.position.x, distance, transform.position.z);
        transform.position = stick;

        float angle = Mathf.Lerp(cameraData.SwivelMinZoom, cameraData.SwivelMaxZoom, zoom);
        swivel = Quaternion.Euler(angle, transform.rotation.y, transform.rotation.z);
        transform.rotation = swivel;
    }

    private void AdjustPosition(float xDelta, float zDelta)
    {
        Vector3 direction = new Vector3(xDelta, 0f, zDelta).normalized;
        float distance = 2f * Time.deltaTime;

        Vector3 position = transform.localPosition;
        position += direction * distance;
        if (!ReachedHorizontalBorders(position) && !ReachedVertcialBoders(position))
        {
            transform.localPosition = position;
        }
    }

    public void SetCameraPosition(float xDiv, float zDiv)
    {
        Vector3 lastPos = transform.position;
        Vector3 newPos = new Vector3(mapData.tilesWidth * xDiv, transform.position.y, mapData.tilesHeight * zDiv);
        transform.DOMove(newPos, 0.4f);
    }

    public Tuple<float, float> GetDivisions()
    {
        Tuple<float, float> div = new Tuple<float, float>(transform.position.x / mapData.tilesWidth, transform.position.z / mapData.tilesHeight);
        return div;
    }
}
