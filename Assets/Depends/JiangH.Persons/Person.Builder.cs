using JiangH.Interfaces;
using System;
using System.Collections.Generic;

namespace JiangH.Persons
{
    public partial class Person
    {
        private static Random random = new Random();

        public static class Builder
        {
            internal static IEnumerable<Person> BuildCollection(int count)
            {
                var rslt = new List<Person>();
                for (int i = 0; i < count; i++)
                {
                    rslt.Add(new Person($"PERSON{i}", random.Next(0,5) < 2 ? IPerson.Gender.female : IPerson.Gender.male));
                }

                return rslt;
            }
        }
    }
}
