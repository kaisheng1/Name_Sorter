using Name_Sorter_Console.Model;
using Name_Sorter_Console.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Name_Sorter_Testing
{
    public class PersonValidatorTest
    {
        private IValidator<Person> _personValidator;
        public PersonValidatorTest()
        {
            _personValidator = new PersonValidator();
        }

        [Fact]
        public void Validate_DoesNotThrow()
        {
            // Arrange
            Person p = new Person { GivenNames = new string[] { "John", "Smith" }, LastName = "" };

            // Act
            _personValidator.Validate(p);
        }

        [Fact]
        public void Validate_Throw_Null()
        {
            // Arrange
            Person p = new Person { GivenNames = null, LastName = "" };

            // Act
            Action act = new Action(() => _personValidator.Validate(p));

            // Assert
            Exception ex = Assert.Throws<ValidationException>(act);
            Assert.Equal("No given names!", ex.Message);
        }

        [Fact]
        public void Validate_Throw_Length_Zero()
        {
            // Arrange
            Person p = new Person { GivenNames = new string[] { }, LastName = "" };

            // Act
            Action act = new Action(() => _personValidator.Validate(p));

            // Assert
            Exception ex = Assert.Throws<ValidationException>(act);
            Assert.Equal("No given names!", ex.Message);
        }

        [Fact]
        public void Validate_Throw_Length_Over_Three()
        {
            // Arrange
            Person p = new Person { GivenNames = new string[] { "John", "Smith" , "C", "A"}, LastName = "" };

            // Act
            Action act = new Action(() => _personValidator.Validate(p));

            // Assert
            Exception ex = Assert.Throws<ValidationException>(act);
            Assert.Equal("Given names are more than 3!", ex.Message);
        }

    }
}
