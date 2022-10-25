using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{

    public static BuildingSystem current;
     // This is for grid snapping

    public GridLayout gridLayout;
    //Public as will be accessed from other scripts
    private Grid grid;
    [SerializedField] private Tilemap MainTilemap;
    //Is initialised in the editor
    [SerializedField] private Tilemap whiteTile;
    // Used to indicate a selected area (turns the tile white)

    public GameObject prefab1;
    public GameObject prefab2;
    // Calls on the prefabs that have been made

    private PlaceableObject objectToPlace;
    // For the placeable object

    #region Unity methods

    private void Awake ()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
        // Intialises the current field and gets the grid from the grid layout
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPoint()
    {
    //Using Raycasting to get the world point
        Ray ray = Camera.main,ScreenPointToRay(Input.mousePosition);
        //Created a ray by calling the ScreenPointToRay method
        if (Physics.Raycastr(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    #endregion
}
