using JiangH.Interfaces;
using System;
using System.Collections.Generic;

namespace JiangH.Persons
{
    public partial class Person
    {
        public static class Builder
        {
            internal static IEnumerable<Person> BuildCollection(int count)
            {
                var rslt = new List<Person>();
                for (int i = 0; i < count; i++)
                {
                    rslt.Add(new Person($"PERSON{i}"));
                }

                return rslt;
            }
        }
    }
}
