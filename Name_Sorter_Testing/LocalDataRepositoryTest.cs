using Name_Sorter_Console.Data;
using Name_Sorter_Console.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace Name_Sorter_Testing
{
    public class LocalDataRepositoryTest
    {
        private IDataRepository _repo;

        public LocalDataRepositoryTest()
        {
            _repo = new LocalDataRepository();
        }
        [Fact]
        public void Get_People_List_Successful()
        {
            // Arrange
            string inputPath = "../../../data/test1.txt";
            List<Person> expected = new List<Person>() { 
                new Person { GivenNames = new string[] { "John" }, LastName = "Ahaha" },
                new Person { GivenNames = new string[] { "Sword" }, LastName = "Blade" },
                new Person { GivenNames = new string[] { "Dangerous", "Kid" }, LastName = "Monster" },
                new Person { GivenNames = new string[] { "A", "B" }, LastName = "C" }
            };

            // Act
            List<Person> personList = _repo.GetPeopleList(inputPath);

            // Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.True(expected[i].CompareTo(personList[i]) == 0);
            }
        }
    }
}
