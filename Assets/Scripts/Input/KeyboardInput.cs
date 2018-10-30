using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyboardInput : MonoBehaviour {

	public event Action ChangeMap;
	public static event Action ToggleShipsScrollBar;
	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.K)) {
			if(ChangeMap != null)
				ChangeMap.Invoke();
		}
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(ToggleShipsScrollBar != null)
				ToggleShipsScrollBar.Invoke();
		}
	}
}
