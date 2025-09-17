using System;
using evidence_pojisteni_basic.Interfaces;
using Serilog;

namespace evidence_pojisteni_basic.Menu
{
    /// <summary>
    /// Handles the menu action for listing all insured persons.
    /// </summary>
    public class ListInsuredHandler : IMenuAction
    {
        private readonly IInsuredService _insuredService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListInsuredHandler"/> class.
        /// </summary>
        /// <param name="insuredService">The service used to manage insured persons.</param>
        public ListInsuredHandler(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        /// <summary>
        /// Displays all insured persons in the system.
        /// </summary>
        public void Execute()
        {
            try
            {
                var insuredList = _insuredService.GetAllInsured();

                if (insuredList.Count == 0)
                {
                    Console.WriteLine("No insured persons found.");
                    return;
                }

                Console.WriteLine("List of insured persons:");
                Console.WriteLine("-------------------------");

                foreach (var person in insuredList)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while listing insured persons.");
                Console.WriteLine("An error occurred while listing insured persons.");
            }
        }
    }
}
