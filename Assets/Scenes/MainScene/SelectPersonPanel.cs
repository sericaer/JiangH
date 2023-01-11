using JiangH.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityUITable;
using MyExtentions;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

class SelectPersonPanel : MonoBehaviour
{
    public Table table;
    public IEnumerable<IPerson> gmData { get; set; }

    public UnityEvent<IPerson> selectPersonEvent;

    public List<Item> items = new List<Item>();

    public void Start()
    {
        Item.actionDoSelect = (person) =>
        {
            selectPersonEvent.Invoke(person);
        };

        items.Clear();
    }

    public void FixedUpdate()
    {
        var needAdds = gmData.Except(items.Select(x => x.person)).ToArray();
        foreach (var person in needAdds)
        {
            var newItem = new Item(person);

            items.Add(newItem);
        }

        var needRemoves = items.Where(i => gmData.All(x => x != i.person)).ToArray();
        foreach (var item in needRemoves)
        {
            items.Remove(item);
        }
    }

    public void SetVaildColums(params string[] columnNames)
    {
        table.SetVaildColumn(columnNames.Append(nameof(Item.Select)).ToArray());
    }

    public class Item : PersonData
    {
        public static Action<IPerson> actionDoSelect;

        public Item(IPerson person) : base(person)
        {
        }

        public void Select()
        {
            actionDoSelect(person);
        }
    }
}
