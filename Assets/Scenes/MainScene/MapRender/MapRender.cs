using JiangH.Interfaces;
using JiangH.Sessions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

class MapRender : MonoBehaviour
{
    public TerrainMap terrainMap;
    public MapCamera mapCamera;
    public MapUICanvas mapUIContainer;

    public Text text;

    void Awake()
    {
        RegionItem.CoordToWord = (coord) => terrainMap.tilemap.CellToWorld(new Vector3Int(coord.x, coord.y));
    }

    // Start is called before the first frame update
    void Start()
    {
        var gmInit = new GMInit()
        {
            mapHeight = 21,
            mapWidth = 31,
            regionCount = 30,
            sectCount = 10
        };

        var session = Session.Builder.Build(gmInit);

        terrainMap.gmData = session.terrainMap;
        mapUIContainer.gmData = session.regions;

        mapCamera.MoveTo(new Coordinate(3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
