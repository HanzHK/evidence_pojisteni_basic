using System;
using evidence_pojisteni_basic.Interfaces;
using evidence_pojisteni_basic.Validation;
using Serilog;

namespace evidence_pojisteni_basic.Menu
{
    /// <summary>
    /// Handles the menu action for removing an insured person by name.
    /// </summary>
    public class RemoveInsuredHandler : IMenuAction
    {
        private readonly IInsuredService _insuredService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveInsuredHandler"/> class.
        /// </summary>
        /// <param name="insuredService">The service used to manage insured persons.</param>
        public RemoveInsuredHandler(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        /// <summary>
        /// Prompts the user for name and removes matching insured persons.
        /// </summary>
        public void Execute()
        {
            try
            {
                string firstName = InputValidator.ReadNonEmptyString("Enter first name: ");
                string lastName = InputValidator.ReadNonEmptyString("Enter last name: ");

                bool removed = _insuredService.RemoveInsured(firstName, lastName);

                if (removed)
                {
                    Console.WriteLine("Insured person successfully removed.");
                }
                else
                {
                    Console.WriteLine("No insured person found with the given name.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while removing an insured person.");
                Console.WriteLine("An error occurred while removing the person.");
            }
        }
    }
}
