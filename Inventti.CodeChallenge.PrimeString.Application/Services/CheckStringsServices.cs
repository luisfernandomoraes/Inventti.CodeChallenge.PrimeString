using System;
using System.Linq;
using System.Text;

namespace Inventti.CodeChallenge.PrimeString.Application.Services
{
    /// <inheritdoc />
    public class CheckStringsServices : ICheckStringsServices
    {
        /// <inheritdoc />
        public bool CheckArePrimes(string firstString, string secondString)
        {
            var primeString = new Domain.Models.PrimeString(firstString, secondString);

            if (!primeString.Invalid) return primeString.ArePrimes();


            var errorsBuilder = new StringBuilder();
            primeString.Notifications.ToList().ForEach(x => errorsBuilder.AppendLine($"{x.Property} : {x.Message}"));

            throw new ArgumentException(errorsBuilder.ToString());
        }
    }
}