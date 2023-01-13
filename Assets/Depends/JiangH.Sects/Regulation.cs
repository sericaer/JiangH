using JiangH.Interfaces;
using System.Collections.Generic;

namespace JiangH.Sects
{
    partial class Sect
    {
        class Regulation : ISect.IRegulation
        {
            public ISect.IRegulation.Group[] groups { get; }

            public Regulation()
            {
                groups = new ISect.IRegulation.Group[]
                {
                    new ISect.IRegulation.Group()
                    {
                        items = new ISect.IRegulation.Item[]
                        {
                            new ISect.IRegulation.Item("IRegulation0_0", null),
                            new ISect.IRegulation.Item("IRegulation0_1", (person)=>person.gender == IPerson.Gender.male),
                            new ISect.IRegulation.Item("IRegulation0_2", (person)=>person.gender == IPerson.Gender.female),
                        }
                    }
                };

                foreach(var group in groups)
                {
                    var index = random.Next(0, group.items.Length);
                    group.vaildItem = group.items[index];
                }
            }
        }
    }
}
