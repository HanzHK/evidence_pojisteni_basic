using System;
using evidence_pojisteni_basic.Interfaces;
using evidence_pojisteni_basic.Models;
using evidence_pojisteni_basic.Validation;
using Serilog;

namespace evidence_pojisteni_basic.Menu
{
    /// <summary>
    /// Handles the menu action for adding a new insured person.
    /// </summary>
    public class AddInsuredHandler : IMenuAction
    {
        private readonly IInsuredService _insuredService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddInsuredHandler"/> class.
        /// </summary>
        /// <param name="insuredService">The service used to manage insured persons.</param>
        public AddInsuredHandler(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        /// <summary>
        /// Collects user input and adds a new insured person to the system.
        /// </summary>
        public void Execute()
        {
            try
            {
                string firstName = InputValidator.ReadNonEmptyString("Enter first name: ");
                string lastName = InputValidator.ReadNonEmptyString("Enter last name: ");
                int age = InputValidator.ReadValidInt("Enter age: ");
                string phoneNumber = InputValidator.ReadNonEmptyString("Enter phone number: ");

                var insuredPerson = new InsuredPerson(firstName, lastName, age, phoneNumber);
                _insuredService.AddInsured(insuredPerson);

                Console.WriteLine("Insured person successfully added.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while adding a new insured person.");
                Console.WriteLine("An error occurred while adding the person.");
            }
        }
    }
}
