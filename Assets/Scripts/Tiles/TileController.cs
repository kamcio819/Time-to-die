using UnityEngine;
using UnityEngine.EventSystems;

public class TileController : MonoBehaviour
{
    private Color prevColor;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        prevColor = GetComponent<MeshRenderer>().materials[0].color;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ChangeTileAlpha();
        }
    }

    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ResetTileAlpha();
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (GetComponent<HexTile>().availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES)
            {
                HighlightTileAlpha();
            }
        }
    }

    private void ChangeTileAlpha()
    {
        meshRenderer.materials[0].SetFloat("_Metallic", 0.05f);
    }

    private void ResetTileAlpha()
    {
        meshRenderer.materials[0].SetFloat("_Metallic", 0.7f);
    }

    public void ChangeColorOfTile(Color color)
    {
        meshRenderer.materials[0].color = color;
    }

    private void HighlightTileAlpha()
    {
        if (meshRenderer.materials[0].color != prevColor)
        {
            ResetTileColor();
        } 
        else
        {
            meshRenderer.materials[0].color = Color.red;
        }
    }

    public void ResetTileColor()
    {
        meshRenderer.materials[0].color = prevColor;
    }
}
