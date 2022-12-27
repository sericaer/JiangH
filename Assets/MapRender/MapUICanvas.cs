using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

class MapUICanvas : MonoBehaviour
{
    public RegionItem defaultRegionItem;
    //public Tilemap tileMap;

    public IEnumerable<IRegion> gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;

            foreach (var region in _gmData)
            {
                var item = Instantiate(defaultRegionItem, defaultRegionItem.transform.parent);
                item.gmData = region;
                item.gameObject.SetActive(true);
            }
        }
    }

    private IEnumerable<IRegion> _gmData;

    void Start()
    {
        defaultRegionItem.gameObject.SetActive(false);
    }

    //public void OnCameraMoved()
    //{
    //    foreach (var item in GetComponentsInChildren<RegionItem>())
    //    {
    //        item.transform.position = tileMap.CellToWorld(new Vector3Int(item.gmData.coordinate.x, item.gmData.coordinate.y));
    //    }
    //}
}
