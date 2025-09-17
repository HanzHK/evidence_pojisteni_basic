// Interfaces/IInsuredService.cs

using System.Collections.Generic;
using evidence_pojisteni_basic.Models;

namespace evidence_pojisteni_basic.Interfaces
{
    /// <summary>
    /// Defines operations for managing insured persons.
    /// </summary>
    public interface IInsuredService
    {
        /// <summary>
        /// Adds a new insured person to the registry.
        /// </summary>
        /// <param name="person">The insured person to add.</param>
        void AddInsured(InsuredPerson person);

        /// <summary>
        /// Returns all insured persons in the registry.
        /// </summary>
        /// <returns>A list of insured persons.</returns>
        List<InsuredPerson> GetAllInsured();

        /// <summary>
        /// Finds insured persons by first and last name.
        /// </summary>
        /// <param name="firstName">First name to search for.</param>
        /// <param name="lastName">Last name to search for.</param>
        /// <returns>A list of matching insured persons.</returns>
        List<InsuredPerson> FindInsured(string firstName, string lastName);

        /// <summary>
        /// Removes insured persons by first and last name.
        /// </summary>
        /// <param name="firstName">First name of the person to remove.</param>
        /// <param name="lastName">Last name of the person to remove.</param>
        /// <returns>True if any person was removed; otherwise, false.</returns>
        bool RemoveInsured(string firstName, string lastName);
    }
}
