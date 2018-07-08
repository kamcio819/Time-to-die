using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {


	private Color prevColor;
	private MeshRenderer meshRenderer;

	void Awake() {
		prevColor = GetComponent<MeshRenderer>().materials[0].color;
		meshRenderer = GetComponent<MeshRenderer>();
	}
	void OnMouseEnter() {
     ChangeTileAlpha();
   }
 	void OnMouseExit() {
     ResetTileAlpha();
 	}

	void OnMouseDown() {
		if(GetComponent<HexTile>().availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES) {
			HighlightTileAlpha();
		}
	}
	void ChangeTileAlpha() {
		meshRenderer.materials[0].SetFloat("_Metallic", 0.05f);
	}
	void ResetTileAlpha() {
		meshRenderer.materials[0].SetFloat("_Metallic", 0.7f);
	}
	void HighlightTileAlpha() {
		if(meshRenderer.materials[0].color == Color.red) {
			ResetTileColor();
		} else {
			meshRenderer.materials[0].color = Color.red;
		}
	}
	void ResetTileColor() {
		meshRenderer.materials[0].color = prevColor;
	}
}
