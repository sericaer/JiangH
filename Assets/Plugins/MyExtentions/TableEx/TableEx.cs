using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUITable;

namespace MyExtentions
{
    public static class TableEx
    {
        public static void SetVaildColumn(this Table table, params string[] columnNames)
        {
            for(int i=0; i<table.columns.Count(); i++)
            {
                table.columns[i].isShow = columnNames.Contains(table.columns[i].fieldName);

                table.headerRow.GetCellAt(i).gameObject.SetActive(table.columns[i].isShow);
            }
        }
    }
}
