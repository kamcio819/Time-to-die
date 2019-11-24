using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInput : MonoBehaviour
{
    public bool leftMouseClicked;
    public bool rightMouseClicked;
    public bool scrollWheelClicked;

    public float scrollWheelInput;
    public float xDelta;
    public float yDelta;

    public float xEdgeScreen;
    public float yEdgeScreen;

    public Vector3 mousePosition;

    public GameObject selectedShip;

    public void OnUpdate()
    {
        leftMouseClicked = Input.GetMouseButton(0);
        scrollWheelClicked = Input.GetMouseButton(2);
        rightMouseClicked = Input.GetMouseButton(1);

        scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        xDelta = Input.GetAxis("Mouse X");
        yDelta = Input.GetAxis("Mouse Y");

        mousePosition = Input.mousePosition;

        CheckForEdge();
    }

    private void CheckForEdge()
    {
        xEdgeScreen = 0f;
        yEdgeScreen = 0f;

        if(Input.mousePosition.x <= Screen.width * 0.02f)
        {
            xEdgeScreen = -0.5f;
        }
        else if(Input.mousePosition.x >= Screen.width * 0.98f)
        {
            xEdgeScreen = 0.5f;
        }
        
        if(Input.mousePosition.y >= Screen.height * 0.98f)
        {
            yEdgeScreen = 0.5f;
        }
        else if(Input.mousePosition.y <= Screen.height * 0.02f)
        {
            yEdgeScreen = -0.5f;
        }
    }
}
