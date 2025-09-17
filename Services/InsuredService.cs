using System;
using System.Collections.Generic;
using System.Linq;
using evidence_pojisteni_basic.Interfaces;
using evidence_pojisteni_basic.Models;
using Serilog;

namespace evidence_pojisteni_basic.Services
{
    /// <summary>
    /// Provides in-memory management of insured persons.
    /// </summary>
    public class InsuredService : IInsuredService
    {
        private readonly List<InsuredPerson> _insuredList = new();

        /// <inheritdoc />
        public void AddInsured(InsuredPerson person)
        {
            try
            {
                _insuredList.Add(person);
                Log.Information("Added insured person: {FirstName} {LastName}", person.FirstName, person.LastName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while adding insured person.");
                throw;
            }
        }

        /// <inheritdoc />
        public List<InsuredPerson> GetAllInsured()
        {
            return _insuredList;
        }

        /// <inheritdoc />
        public List<InsuredPerson> FindInsured(string firstName, string lastName)
        {
            return _insuredList
                .Where(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
                         && p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <inheritdoc />
        public bool RemoveInsured(string firstName, string lastName)
        {
            var found = FindInsured(firstName, lastName);
            if (found.Count == 0)
                return false;

            foreach (var person in found)
            {
                _insuredList.Remove(person);
                Log.Information("Removed insured person: {FirstName} {LastName}", person.FirstName, person.LastName);
            }

            return true;
        }
    }
}
