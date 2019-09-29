using System;
using FluentAssertions;
using Inventti.CodeChallenge.PrimeString.Application.Services;
using Xunit;

namespace Inventti.CodeChallenge.PrimeString.Test.Unit
{
    public class CheckStringsServicesTest
    {
        [Theory(DisplayName = "Deve retornar um ArgumentException para valores inválidos")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("", null)]
        public void Should_Be_Return_A_Argument_Exception_With_Two_Messages(string firstString, string secondString)
        {
            // Arr
            CheckStringsServices checkStringsServices = new CheckStringsServices();

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => checkStringsServices.CheckArePrimes(firstString, secondString));

            // Ass
            var s = exception.Message;
            exception.Message.Should().Be("firstString : O valor não pode ser nulo ou vazio.\r\nsecondString : O valor não pode ser nulo ou vazio.\r\n");
        }

        [Theory(DisplayName = "Deve retornar um ArgumentException para valores inválidos")]
        [InlineData(null, "test")]
        [InlineData("", "test")]
        public void Should_Be_Return_A_Argument_Exception_With_One_Messages(string firstString, string secondString)
        {
            // Arr
            CheckStringsServices checkStringsServices = new CheckStringsServices();

            // Act
            ArgumentException exception = Assert.Throws<ArgumentException>(() => checkStringsServices.CheckArePrimes(firstString, secondString));

            // Ass
            exception.Message.Should().Be("firstString : O valor não pode ser nulo ou vazio.\r\n");
        }
    }
}