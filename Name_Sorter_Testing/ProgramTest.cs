using System;
using Xunit;
using Name_Sorter_Console;
using Name_Sorter_Console.Data;
using Name_Sorter_Console.Model;
using System.Collections.Generic;
using Name_Sorter_Console.Service;

namespace Name_Sorter_Testing
{
    public class ProgramTest
    {
        private IDataRepository _repo;
        private string _inputPath = "../../../data/test1.txt";
        private string _outputPath = "../../../output/sorted-names-list.txt";
        public ProgramTest()
        {
            _repo = new LocalDataRepository(_inputPath);
        }
        [Fact]
        public void Program_Successful()
        {
            // Arrange

            // Act
            new Program(_inputPath, _outputPath, new SortPersonService()).Run();
            List<Person> personList = _repo.GetPeopleList();

            // Assert
            Assert.Equal(4, personList.Count);
        }
    }
}
