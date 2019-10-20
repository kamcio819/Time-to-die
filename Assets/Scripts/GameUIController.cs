using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour {

	[SerializeField]
	private GameObject ShipsScrollView = default;


	// Use this for initialization
	void OnEnable () {
		KeyboardInput.ToggleShipsScrollBar += ToggleScrollBar;
	}

   private void ToggleScrollBar()
   {
      ShipsScrollView.SetActive(!ShipsScrollView.gameObject.activeInHierarchy);
   }

   // Update is called once per frame
   void Update () {
		
	}
}
