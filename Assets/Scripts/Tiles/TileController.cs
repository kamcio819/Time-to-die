using UnityEngine;
using UnityEngine.EventSystems;

public class TileController : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private HexTile hexTile;

    public Color ClickedColor = Color.red;

    private Color prevColor;

    private void Awake()
    {
        prevColor = meshRenderer.materials[0].color;
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
            if (hexTile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES)
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
            meshRenderer.materials[0].color = ClickedColor;
        }
    }

    public void ResetTileColor()
    {
        meshRenderer.materials[0].color = prevColor;
    }
}
