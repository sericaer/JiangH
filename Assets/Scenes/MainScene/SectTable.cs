using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class SectTable : MonoBehaviour
{
    public List<SectData> sectDatas = new List<SectData>();

    public IEnumerable<ISect> gmData { get; set; }

    public void Start()
    {
        sectDatas.Clear();
    }

    public void FixedUpdate()
    {
        foreach(var sect in gmData)
        {
            if(sectDatas.All(x=>x.sect != sect))
            {
                sectDatas.Add(new SectData(sect));
            }
        }

        foreach(var sectData in sectDatas)
        {
            if(gmData.All(x=>x != sectData.sect))
            {
                sectDatas.Remove(sectData);
            }
        }
    }
}

public class SectData
{
    public SectData(ISect sect)
    {
        this.sect = sect;
    }

    public ISect sect { get; }
    public string name => sect.name;
    public int regionCount => sect.regions.Count();

    public int treasuryCurrent => sect.treasury.current;

    public int treasurySurplus => sect.treasury.surplus;
}