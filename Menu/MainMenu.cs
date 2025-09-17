using System;
using System.Collections.Generic;
using evidence_pojisteni_basic.Interfaces;
using evidence_pojisteni_basic.Menu;

namespace evidence_pojisteni_basic
{
    /// <summary>
    /// Displays the main menu and routes user actions to appropriate handlers.
    /// </summary>
    public class MainMenu
    {
        private readonly Dictionary<string, IMenuAction> _actions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        /// <param name="insuredService">The service used to manage insured persons.</param>
        public MainMenu(IInsuredService insuredService)
        {
            _actions = new Dictionary<string, IMenuAction>
            {
                { "1", new AddInsuredHandler(insuredService) },
                { "2", new ListInsuredHandler(insuredService) },
                { "3", new FindInsuredHandler(insuredService) },
                { "4", new RemoveInsuredHandler(insuredService) }
            };
        }

        /// <summary>
        /// Starts the main menu loop and handles user input.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Insured Registry");
                Console.WriteLine("----------------");
                Console.WriteLine("1 - Add new insured person");
                Console.WriteLine("2 - List all insured persons");
                Console.WriteLine("3 - Find insured person");
                Console.WriteLine("4 - Remove insured person");
                Console.WriteLine("5 - Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine()?.Trim();

                if (input == "5")
                {
                    Console.WriteLine("Exiting application...");
                    return;
                }

                if (_actions.TryGetValue(input, out var action))
                {
                    action.Execute();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
