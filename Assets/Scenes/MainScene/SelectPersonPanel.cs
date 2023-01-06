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
    public Button confirm;
    public Button cancel;

    public Table table;
    public IEnumerable<IPerson> gmData { get; set; }

    public UnityEvent<IEnumerable<IPerson>> selectPersonsEvent;

    public List<Item> items = new List<Item>();

    public void Start()
    {
        items.Clear();

        confirm.onClick.AddListener(() =>
        {
            selectPersonsEvent.Invoke(items.Where(x => x.isSelect).Select(x=>x.person));
        });

        cancel.onClick.AddListener(() =>
        {
            Destroy(this.gameObject);
        });

        confirm.interactable = false;
    }

    public void FixedUpdate()
    {
        var needAdds = gmData.Except(items.Select(x => x.person)).ToArray();
        foreach (var person in needAdds)
        {
            var newItem = new Item(person);
            newItem.actionDoSelect = (flag) =>
            {
                if (flag)
                {
                    foreach (var item in items.Where(x => x != newItem))
                    {
                        item.isSelect = false;
                    }
                }

                confirm.interactable = items.Any(x => x.isSelect);
            };

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
        table.SetVaildColumn(columnNames.Append(nameof(Item.isSelect)).ToArray());
    }

    public class Item : PersonData
    {
        public Action<bool> actionDoSelect;

        public bool isSelect
        {
            get
            {
                return _isSelect;
            }
            set
            {
                if (_isSelect == value)
                {
                    return;
                }

                _isSelect = value;

                actionDoSelect(value);
            }
        }

        private bool _isSelect;
        public Item(IPerson person) : base(person)
        {
        }
    }
}
