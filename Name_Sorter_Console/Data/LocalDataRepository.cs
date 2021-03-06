using Name_Sorter_Console.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Name_Sorter_Console.Services;

namespace Name_Sorter_Console.Data
{
    public class LocalDataRepository : IDataRepository
    {
        private IValidator<Person> _personValidator;
        private string _inputPath;
        public LocalDataRepository(string inputPath)
        {
            _personValidator = new PersonValidator();
            _inputPath = inputPath;
        }

        /// <summary>
        /// Returns a list of People model.
        /// </summary>
        /// <param name="inputPath">The path of the input file.</param>
        /// <returns>personList, which is a list of People model.</returns>
        public List<Person> GetPeopleList() 
        {
            string[] lines = File.ReadAllLines(_inputPath);
            List<Person> personList = new List<Person>();

            foreach (string line in lines)
            {
                string[] names = line.Split(" ");
                string[] givenNames = names.SkipLast(1).ToArray();

                Person p = new Person { GivenNames = givenNames, LastName = names.Last() };
                _personValidator.Validate(p);
                personList.Add(p);
            }

            return personList;
        }
    }
}
