using JiangH.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

class TerrainMap : MonoBehaviour
{
    public Tilemap tilemap;

    public Dictionary<TerrainType, Color> colors = new Dictionary<TerrainType, Color>()
    {
        { TerrainType.Plain, Color.green},
        { TerrainType.Hill, Color.yellow},
        { TerrainType.Mount, new Color(128 / 255f, 0, 128 / 255f)}
    };

    public ITerrainMap gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;

            tilemap.ClearAllTiles();

            foreach (var pair in _gmData)
            {
                tilemap.SetTileColor(new Vector3Int(pair.Key.x, pair.Key.y), colors[pair.Value]);
            }
        }
    }

    private ITerrainMap _gmData;
}
