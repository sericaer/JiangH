using System;
using System.Collections.Generic;

namespace JiangH.Interfaces
{
    public interface ISect
    {
        string name { get; }

        IEnumerable<IPerson> persons { get; }
        IEnumerable<IRegion> regions { get; }

        IRegion location { get; }

        ITreasury treasury { get; }

        IEnumerable<IPerson> willJoininPersons { get; }

        IRegulation regulation { get; }


        interface IRegulation
        {
            class Item
            {
                public string name { get; }
                public Func<IPerson, bool> RecruitLimit { get; }

                public Item(string name, Func<IPerson, bool> RecruitLimit)
                {
                    this.name = name;
                    this.RecruitLimit = RecruitLimit;
                }
            }

            class Group
            {
                public Item vaildItem
                {
                    get
                    {
                        return _vaildItem;
                    }
                    set
                    {
                        if(!Array.Exists(items, x=>x == value))
                        {
                            throw new Exception();
                        }

                        _vaildItem = value;
                    }
                }

                public Item[] items;

                private Item _vaildItem;
            }

            Group[] groups { get; }
        }
    }
}
