using Name_Sorter_Console.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Name_Sorter_Console.Services
{
    public class PersonValidator : IValidator<Person>
    {
        /// <summary>
        /// Check if a person is valid.
        /// </summary>
        /// <param name="person">an instance of Person model.</param>
        /// <exception cref="ValidationException">Thrown if givenNames are null or its length <= 0 or > 3.</exception>
        public void Validate(Person person)
        {
            if (person.GivenNames == null || person.GivenNames.Length <= 0) throw new ValidationException("No given names!");
            if (person.GivenNames.Length > 3) throw new ValidationException("Given names are more than 3!");
        }
    }
}
