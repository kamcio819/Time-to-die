using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshottaker : MonoBehaviour {
	
	// Update is called once per frame

	int i = 0;


	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
			ScreenCapture.CaptureScreenshot("C:/Users/Kamil/Desktop/lol" + i.ToString() + ".png", 4);
			i++;
		}
	}
}
