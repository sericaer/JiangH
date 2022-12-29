using JiangH.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

class RegionItem : MonoBehaviour
{
    public Text text;
    public SectPanel sectPanel;

    public static Func<Coordinate, Vector3> CoordToWord { get; set; }

    public IRegion gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;
            text.text = _gmData.name;
            this.transform.position = CoordToWord(_gmData.coordinate);
        }
    }

    private IRegion _gmData;

    void Update()
    {
        sectPanel.gmData = _gmData.sect;
    }

}
