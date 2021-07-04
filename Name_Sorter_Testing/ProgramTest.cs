using System;
using Xunit;
using Name_Sorter_Console;
using Name_Sorter_Console.Data;
using Name_Sorter_Console.Model;
using System.Collections.Generic;

namespace Name_Sorter_Testing
{
    public class ProgramTest
    {
        private IDataRepository _repo;
        public ProgramTest()
        {
            _repo = new LocalDataRepository();
        }
        [Fact]
        public void Program_Successful()
        {
            // Arrange
            string inputPath = "../../../data/test1.txt";
            string outputPath = "../../../output/sorted-names-list.txt";

            // Act
            new Program(inputPath, outputPath).Run();
            List<Person> personList = _repo.GetPeopleList(outputPath);

            // Assert
            Assert.Equal(4, personList.Count);
        }
    }
}
