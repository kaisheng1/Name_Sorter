using System;
using Xunit;
using Name_Sorter_Console.Model;

namespace Name_Sorter_Testing
{
    public class PersonTest
    {
        [Fact]
        public void GetFullName_Sucessful()
        {
            // Arrange
            string[] givenNames = { "John", "Smith" };
            string lastName = "Samza";
            Person person = new Person { GivenNames = givenNames, LastName = lastName };
            // Act
            string actual = person.FullName;

            // Assert
            Assert.Equal("John Smith Samza", actual);
        }

       
        [Fact]
        public void CompareTo_Successful_Negative_DifferentLastName()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "A" }; 
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "B" }; 

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare < 0);
        }

        [Fact]
        public void CompareTo_Successful_Negative_SameLastName_DifferentGivenNames_SameLength()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "Aohn" }, LastName = "A" };
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "A" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare < 0);
        }

        [Fact]
        public void CompareTo_Successful_Negative_SameLastName_DifferentGivenNames_DifferentLength()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "B" };
            Person p2 = new Person { GivenNames = new string[] { "John", "E" }, LastName = "B" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare < 0);
        }

        [Fact]
        public void CompareTo_Successful_Positive_DifferentLastName()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "B" };
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "A" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare > 0);
        }

        [Fact]
        public void CompareTo_Successful_Positive_SameLastName_DifferentGivenNames_SameLength()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John" }, LastName = "A" };
            Person p2 = new Person { GivenNames = new string[] { "Aohn" }, LastName = "A" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare > 0);
        }

        [Fact]
        public void CompareTo_Successful_Positive_SameLastName_DifferentGivenNames_DifferentLength()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John", "E" }, LastName = "A" };
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "A" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare > 0);
        }

        [Fact]
        public void CompareTo_Successful_Zero()
        {
            // Arrange
            Person p1 = new Person { GivenNames = new string[] { "John"}, LastName = "" };
            Person p2 = new Person { GivenNames = new string[] { "John" }, LastName = "" };

            // Act
            int compare = p1.CompareTo(p2);

            // Assert
            Assert.True(compare == 0);
        }
    }
}
