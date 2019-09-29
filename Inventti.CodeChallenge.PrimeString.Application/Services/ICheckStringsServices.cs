namespace Inventti.CodeChallenge.PrimeString.Application.Services
{
    /// <summary>
    /// Serviço para comparar strings.
    /// </summary>
    public interface ICheckStringsServices
    {
        /// <summary>
        /// Verifica se as strings são primas.
        /// </summary>
        /// <param name="firstString">Primeira string usada na comparação.</param>
        /// <param name="secondString">Segunda string usada na comparação.</param>
        /// <returns></returns>
        bool CheckArePrimes(string firstString, string secondString);
    }
}