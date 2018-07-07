using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CameraData {

	 //To manipulate through Inspector only
    #region Init Values of Camera

    [SerializeField]
	 [Range(0, 10)]
    float stickMinZoom;

	 public float StickMinZoom { get {return stickMinZoom;} private set{}}

    [SerializeField]
	 [Range(-2, 2)]
    float stickMaxZoom;

	 public float StickMaxZoom { get {return stickMaxZoom;} private set{}}

    [SerializeField]
	 [Range(0, 100)]
    float swivelMinZoom;

	 public float SwivelMinZoom {get {return swivelMinZoom;} private set{}}

    [SerializeField]
	 [Range(0, 100)]
    float swivelMaxZoom;

	 public float SwivelMaxZoom { get {return swivelMaxZoom;} private set{}}

	 public GameObject focusedMap;

    public Transform centerTile;

    #endregion
}
