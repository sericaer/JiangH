using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityUITable;
using MyExtentions;
using System;

class PersonTable : MonoBehaviour
{
    public List<PersonData> items = new List<PersonData>();

    public Table table;


    public IEnumerable<IPerson> gmData { get; set; }

    public void Start()
    {
        items.Clear();
    }

    public void FixedUpdate()
    {
        foreach (var person in gmData)
        {
            if (items.All(x => x.person != person))
            {
                var personData = new PersonData(person);
                items.Add(personData);
            }
        }

        foreach (var item in items)
        {
            if (gmData.All(x => x != item.person))
            {
                items.Remove(item);
            }
        }
    }

    public void SetVaildColums(params string[] columnNames)
    {
        table.SetVaildColumn(columnNames);
    }
}

public class PersonData
{
    public readonly IPerson person;

    public PersonData(IPerson person)
    {
        this.person = person;
    }

    public string name => person.name;

    public string gender => person.gender.ToString();
    public string sect => person.sect != null ? person.sect.name : "--";
    public string office => person.office != null ? person.office.name : "--";
    public string salary => person.sect != null ? person.salary.value.ToString() : "--";
    public string patrolRegion => person.patrolRegion != null ? person.patrolRegion.name : "--";
}
