using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;
    public bool IsPollutant;
    public bool IsMoneyMaker;
    public bool IsMoneySpender;
    public List<GameObject> Pollutants;
    public List<GameObject> MoneyMakers;
    public List<GameObject> MoneySpenders;

    public GameObject prefabH;
    public GameObject prefabF;
    public GameObject prefabPP;
    public GameObject prefabW;
    public GameObject GameManager;
    public GameObject AlertSystem;
    public Animation alertAnim;

    public Text Message;


    private bool isPlacing = false;
    private GameObject placingObject;

    private PlaceableObject objectToPlace;
    [SerializeField]
    public MoneySystem moneySystemRef;

    private AudioSource clunkAudio;

    #region Unity methods

    void Start()
    {
        clunkAudio = GameObject.Find ("AudioManager").GetComponent<AudioSource> ();
    }
 

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {



        if (!objectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            objectToPlace.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.Size);
                clunkAudio.Play();
                moneySystemRef.MoneyBarLvl -= 300;
                isPlacing = false;
            }
            else
            {
                AlertSystem.SetActive(true);
                Message.text = "WARNING! Cannot be placed here!"; 
                alertAnim.Play("PopupAnim");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPlacing == true)
        {
            /*DestroyImmediate(placingObject, true);
            objectToPlace = null;
            isPlacing = false;*/
        }
    }

    

    public void Factory()
    {
        if(isPlacing == false)
            if (isPlacing == false)
            {
                IsPollutant = true;
                IsMoneySpender = false;
                IsMoneyMaker = true;
                InitializeWithObject(prefabF);
                placingObject = prefabF;

                Debug.Log("Placement with if statement is working");

                isPlacing = true;
            }
            else
            {
                Debug.Log("isPlacing is set to true");
            }
    }

    public void windmil()
    {
        if (isPlacing == false)
        {
            IsPollutant = false;
            IsMoneySpender = true;
            IsMoneyMaker = false;
            InitializeWithObject(prefabW);

            Debug.Log("Placement with if statement is working");

            isPlacing = true;
        }
        else
        {
            Debug.Log("isPlacing is set to true");
        }
    }

    public void house()
    {
        if(isPlacing == false)
        {
        IsPollutant = false;
        IsMoneySpender = false;
        IsMoneyMaker = true;
        InitializeWithObject(prefabH);
        
        Debug.Log("Placement with if statement is working");
        
        isPlacing = true;
        }
        else{
            Debug.Log("isPlacing is set to true");
        }
        
    }

    public void powerplant()
    {
        if (isPlacing == false)
        {
            IsPollutant = false;
            IsMoneySpender = false;
            IsMoneyMaker = true;
            InitializeWithObject(prefabPP);

            Debug.Log("Placement with if statement is working");

            isPlacing = true;
        }
        else
        {
            Debug.Log("isPlacing is set to true");
        }
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
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

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();

        if (obj.GetComponent<BuildingAttributes>().PollutionVal != 0)
        {
            Pollutants.Add(obj);
            GameObject.Find("GameManager").GetComponent<GameplayManager>().UpdatePollution();
        }
        if (obj.GetComponent<BuildingAttributes>().MoneyVal != 0)
        {
            MoneySpenders.Add(obj);
            Debug.Log("I AM SPENDING UR MONEY");
            GameObject.Find("GameManager").GetComponent<GameplayManager>().UpdateMoney();
        }
    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = placeableObject.Size;
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
        MainTilemap.BoxFill(start, whiteTile, start.x, start.y, 
                        start.x + size.x, start.y + size.y);
    }

    #endregion
}
