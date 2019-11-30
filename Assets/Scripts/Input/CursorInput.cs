using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInput : MonoBehaviour
{
    public bool LeftMouseClicked;
    public bool RightMouseClicked;
    public bool ScrollWheelClicked;

    public float ScrollWheelInput;
    public float XInputDelta;
    public float YInputDelta;

    public float XEdgeScreen;
    public float YEdgeScreen;

    public Vector3 MousePosition;

    public GameObject SelectedObject;

    public void OnUpdate()
    {
        GetMouseActionsInput();

        GetMouseAxisInput();

        CheckForEdge();
    }

    private void GetMouseAxisInput()
    {
        XInputDelta = Input.GetAxis("Mouse X");
        YInputDelta = Input.GetAxis("Mouse Y");
    }

    private void GetMouseActionsInput()
    {
        LeftMouseClicked = Input.GetMouseButton(0);
        ScrollWheelClicked = Input.GetMouseButton(2);
        RightMouseClicked = Input.GetMouseButton(1);

        ScrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        MousePosition = Input.mousePosition;
    }

    private void CheckForEdge()
    {
        XEdgeScreen = 0f;
        YEdgeScreen = 0f;

        if(Input.mousePosition.x <= Screen.width * 0.02f)
        {
            XEdgeScreen = -0.5f;
        }
        else if(Input.mousePosition.x >= Screen.width * 0.98f)
        {
            XEdgeScreen = 0.5f;
        }
        
        if(Input.mousePosition.y >= Screen.height * 0.98f)
        {
            YEdgeScreen = 0.5f;
        }
        else if(Input.mousePosition.y <= Screen.height * 0.02f)
        {
            YEdgeScreen = -0.5f;
        }
    }
}
