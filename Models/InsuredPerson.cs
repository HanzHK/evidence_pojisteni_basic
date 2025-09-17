using System;

namespace evidence_pojisteni_basic.Models
{
    /// <summary>
    /// Represents an insured person with basic personal information.
    /// </summary>
    public class InsuredPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public InsuredPerson(string firstName, string lastName, int age, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Returns a formatted string with insured person's details.
        /// </summary>
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age: {Age}, Phone: {PhoneNumber}";
        }
    }
}

