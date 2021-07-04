using Name_Sorter_Console.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Name_Sorter_Console.Model
{
    public class Person : IComparable<Person>
    {
        public string[] GivenNames { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{string.Join(" ", GivenNames)} {LastName}"; } }

        public int CompareTo(Person p)
        {
            if (LastName.Equals(p.LastName))
            {
                return string.Join(" ", GivenNames).CompareTo(string.Join(" ", p.GivenNames));
            }

            return LastName.CompareTo(p.LastName);
        }
    }
}
