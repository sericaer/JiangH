using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class PersonTable : MonoBehaviour
{
    public List<PersonData> items = new List<PersonData>();

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
                items.Add(new PersonData(person));
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
}

public class PersonData
{
    public readonly IPerson person;

    public PersonData(IPerson person)
    {
        this.person = person;
    }

    public string name => person.name;
    public string sect => person.sect != null ? person.sect.name : "--";
    public string salary => person.sect != null ? person.salary.value.ToString() : "--";
    public string patrolRegion => person.patrolRegion != null ? person.patrolRegion.name : "--";
}
