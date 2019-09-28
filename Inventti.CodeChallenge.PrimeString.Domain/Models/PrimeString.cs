using System.Linq;
using FluentValidator;

namespace Inventti.CodeChallenge.PrimeString.Domain.Models
{
    /// <summary>
    /// Objeto que identifica se as strings são primas.
    /// </summary>
    public class PrimeString : Notifiable
    {
        private readonly string _firstString;
        private readonly string _secondString;

        /// <summary>
        /// Inicializa um objeto PrimeString.
        /// </summary>
        /// <param name="firstString">Primeira string usada na comparação.</param>
        /// <param name="secondString">Segunda string usada na comparação.</param>
        public PrimeString(string firstString, string secondString)
        {
            if (string.IsNullOrEmpty(firstString))
                AddNotification(nameof(firstString), "O valor não pode ser nulo ou vazio.");
            _firstString = firstString;
            if (string.IsNullOrEmpty(secondString))
                AddNotification(nameof(secondString), "O valor não pode ser nulo ou vazio.");
            _secondString = secondString;
        }

        /// <summary>
        /// Verifica se as strings são primas.
        /// A Definição de string prima é a seguinte:
        /// "Uma String é considerada prima se ambas tem o mesmo tamanho, e se todos os caracteres em posições impares na primeira String estão em posições impares na segunda String,
        /// e se todos os caracteres em posições pares na primeira String estão em posições pares na segunda String."
        /// </summary>
        /// <returns></returns>
        public bool ArePrimes()
        {
            if (_firstString.Length != _secondString.Length || string.IsNullOrEmpty(_firstString))
                return false;

            var resultForEven = CheckEvenPositions(_firstString, _secondString);
            var resultForOdd = CheckOddPositions(_firstString, _secondString);

            return resultForEven && resultForOdd;
        }

        /// <summary>
        /// Verifica se as strings são primas analisando os indices pares.
        /// </summary>
        /// <param name="firstString">Primeira string usada na comparação.</param>
        /// <param name="secondString">Segunda string usada na comparação.</param>
        /// <returns></returns>
        private bool CheckEvenPositions(string firstString, string secondString)
        {
            var evenElementsFromFirstString =
                _firstString.Select((value, index) => (value, index)).Where(item => item.index % 2 == 0).ToList();

            var evenElementsFromSecondString =
                _secondString.Select((value, index) => (value, index)).Where(item => item.index % 2 == 0).ToList();


            var result = evenElementsFromFirstString.TrueForAll(valueTuple=> evenElementsFromSecondString.Exists(x => x.value == valueTuple.value));

            return result;
        }

        /// <summary>
        /// Verifica se as strings são primas analisando os indices impares.
        /// </summary>
        /// <param name="firstString">Primeira string usada na comparação.</param>
        /// <param name="secondString">Segunda string usada na comparação.</param>
        /// <returns></returns>
        private bool CheckOddPositions(string firstString, string secondString)
        {
            var oddElementsFromFirstString =
                _firstString.Select((value, index) => (value, index)).Where(item => item.index % 2 != 0).ToList();

            var oddElementsFromSecondString =
                _secondString.Select((value, index) => (value, index)).Where(item => item.index % 2 != 0).ToList();

            var result = oddElementsFromFirstString.TrueForAll(valueTuple=> oddElementsFromSecondString.Exists(x => x.value == valueTuple.value));

            return result;
        }
    }
}