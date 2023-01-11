using JiangH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

class SectTable : MonoBehaviour
{
    public List<SectData> sectDatas = new List<SectData>();

    public IEnumerable<ISect> gmData { get; set; }

    public UnityEvent<ISect> showSectDetail;

    public void Start()
    {
        SectData.actionDetail = (sect) => showSectDetail.Invoke(sect);
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
    public static Action<ISect> actionDetail;

    public SectData(ISect sect)
    {
        this.sect = sect;
    }

    public ISect sect { get; }
    public string name => sect.name;
    public string location => sect.location.name;
    public int personCount => sect.persons.Count();
    public int regionCount => sect.regions.Count();
    public int treasuryCurrent => sect.treasury.current;
    public int treasurySurplus => sect.treasury.surplus;

    public void OnDetail()
    {
        actionDetail(sect);
    }
}