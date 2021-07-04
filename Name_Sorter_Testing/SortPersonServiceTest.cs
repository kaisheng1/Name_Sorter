using Name_Sorter_Console.Model;
using Name_Sorter_Console.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace Name_Sorter_Testing
{
    public class SortPersonServiceTest
    {
        private ISortService<Person> _sortPersonService;
        public SortPersonServiceTest()
        {
            _sortPersonService = new SortPersonService();
        }


        [Fact]
        public void Sort_Successful_DifferentLastName()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "D" };
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "A" };
            Person p3 = new Person { GivenNames = new string[] { "John" }, LastName = "B" };
            Person p4 = new Person { GivenNames = new string[] { "John" }, LastName = "C" };
            List<Person> unsortedList = new List<Person>();
            unsortedList.Add(p1);
            unsortedList.Add(p2);
            unsortedList.Add(p3);
            unsortedList.Add(p4);

            List<Person> expected = new List<Person>();
            expected.Add(p2);
            expected.Add(p3);
            expected.Add(p4);
            expected.Add(p1);

            // Act
            List<Person> sortedList = _sortPersonService.Sort(unsortedList);

            // Assert
            Assert.Equal(expected, sortedList);
        }

        [Fact]
        public void Sort_Successful_SameLastName_DifferentGivenNames()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "D" };
            Person p2 = new Person { GivenNames = new string[] { "Aohn" }, LastName = "D" };
            Person p3 = new Person { GivenNames = new string[] { "Bohn" }, LastName = "D" };
            Person p4 = new Person { GivenNames = new string[] { "Cohn" }, LastName = "D" };
            List<Person> unsortedList = new List<Person>();
            unsortedList.Add(p1);
            unsortedList.Add(p2);
            unsortedList.Add(p3);
            unsortedList.Add(p4);

            List<Person> expected = new List<Person>();
            expected.Add(p2);
            expected.Add(p3);
            expected.Add(p4);
            expected.Add(p1);

            // Act
            List<Person> sortedList = _sortPersonService.Sort(unsortedList);

            // Assert
            Assert.Equal(expected, sortedList);
        }

        [Fact]
        public void Sort_Successful_DifferentLastName_DifferentGivenNames()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "D" };
            Person p2 = new Person { GivenNames = new string[] { "Aohn" }, LastName = "B" };
            Person p3 = new Person { GivenNames = new string[] { "Bohn" }, LastName = "B" };
            Person p4 = new Person { GivenNames = new string[] { "Cohn" }, LastName = "A" };
            List<Person> unsortedList = new List<Person>();
            unsortedList.Add(p1);
            unsortedList.Add(p2);
            unsortedList.Add(p3);
            unsortedList.Add(p4);

            List<Person> expected = new List<Person>();
            expected.Add(p4);
            expected.Add(p2);
            expected.Add(p3);
            expected.Add(p1);

            // Act
            List<Person> sortedList = _sortPersonService.Sort(unsortedList);

            // Assert
            Assert.Equal(expected, sortedList);
        }
    }
}
