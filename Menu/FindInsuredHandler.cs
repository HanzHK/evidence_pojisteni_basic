using System;
using evidence_pojisteni_basic.Interfaces;
using evidence_pojisteni_basic.Validation;
using Serilog;

namespace evidence_pojisteni_basic.Menu
{
    /// <summary>
    /// Handles the menu action for finding an insured person by name.
    /// </summary>
    public class FindInsuredHandler : IMenuAction
    {
        private readonly IInsuredService _insuredService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindInsuredHandler"/> class.
        /// </summary>
        /// <param name="insuredService">The service used to manage insured persons.</param>
        public FindInsuredHandler(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        /// <summary>
        /// Prompts the user for name and displays matching insured persons.
        /// </summary>
        public void Execute()
        {
            try
            {
                string firstName = InputValidator.ReadNonEmptyString("Enter first name: ");
                string lastName = InputValidator.ReadNonEmptyString("Enter last name: ");

                var matches = _insuredService.FindInsured(firstName, lastName);

                if (matches.Count == 0)
                {
                    Console.WriteLine("No insured persons found with the given name.");
                    return;
                }

                Console.WriteLine("Matching insured persons:");
                Console.WriteLine("--------------------------");

                foreach (var person in matches)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while searching for insured persons.");
                Console.WriteLine("An error occurred while searching for insured persons.");
            }
        }
    }
}
