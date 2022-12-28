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

    internal void SetSession(ISession session)
    {
        terrainMap.gmData = session.terrainMap;
        mapUIContainer.gmData = session.regions;

        mapCamera.MoveTo(new Coordinate(3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
