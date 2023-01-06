using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

class RegionTable : MonoBehaviour
{
    public List<RegionData> regionDatas = new List<RegionData>();

    public IEnumerable<IRegion> gmData { get; set; }

    public UnityEvent<IRegion> showRegionDetail;

    public void Start()
    {
        RegionData.actionDetail = (region) => showRegionDetail.Invoke(region);

        regionDatas.Clear();
    }

    public void FixedUpdate()
    {
        foreach (var region in gmData)
        {
            if (regionDatas.All(x => x.region != region))
            {
                regionDatas.Add(new RegionData(region));
            }
        }

        foreach (var regionData in regionDatas)
        {
            if (gmData.All(x => x != regionData.region))
            {
                regionDatas.Remove(regionData);
            }
        }
    }

}

public class RegionData
{
    public static Action<IRegion> actionDetail;

    public readonly IRegion region;

    public RegionData(IRegion region)
    {
        this.region = region;
    }

    public string name => region.name;
    public string sect => region.sect != null ? region.sect.name : "--";
    public string collectRatio => region.sect != null ? $"{region.collectRatio}%" : "--";
    public int patrolerCount => region.patrolers.Count();
    public double treasuryProduct => region.productor.value;

    public void OnDetail()
    {
        actionDetail(region);
    }
}