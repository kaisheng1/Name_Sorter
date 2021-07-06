using Name_Sorter_Console.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter_Console.Data
{
    public interface IDataRepository
    {
        public List<Person> GetPeopleList();
    }
}
