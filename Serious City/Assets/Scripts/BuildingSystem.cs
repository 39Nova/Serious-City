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

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
        // Intialises the current field and gets the grid from the grid layout
    }

<<<<<<< Updated upstream
=======
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeWithObject(prefab1);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(prefab2);
        }
        if (!objectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.Size);
            }
            else
            {
                Destroy(objectToPlace.gameObject);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objectToPlace.gameObject);
        }
    }

>>>>>>> Stashed changes
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

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++; 
        }

        return array;
    }

    #endregion
<<<<<<< Updated upstream
=======

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
    

    Vector3 position = SnapCoordinateToGrid(Vector3.zero);

    GameObject obj = Instantiate(prefab, position, Quaternion.identity);
    objectToPlace = obj.GetComponent<PlaceableObject>();
    obj.AddComponent<ObjectDrag>();

    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);

        foreach (var b in baseArray)
        {
            if (b == whiteTile)
            {
                return false;
            }
        }

        return true; 
    }

    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTilemap.BoxFill(start, whiteTile, startX: start.x, startY: start.y,
                            start.x + size.x, start.y + size.y);
    }

    #endregion
>>>>>>> Stashed changes
}
