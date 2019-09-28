using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Inventti.CodeChallenge.PrimeString.Test.Unit
{
    public class PrimeStringTest
    {
        [Fact(DisplayName = "Validação de parâmetros incorretos.")]
        public void Should_Be_Invalid_Values_For_Prime_String()
        {
            // Arr 
            var primeString = new Domain.Models.PrimeString("", "");

            // Act
            var result = primeString.ArePrimes();
            
            // Ass
            primeString.Valid.Should().BeFalse();
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Objeto em estado invalido com duas notificações de domínio")]
        public void Should_Be_Invalid_Values_For_Prime_String_With_Two_Notification()
        {
            // Arr 
            var primeString = new Domain.Models.PrimeString("", "");

            // Act
            var result = primeString.ArePrimes();
            
            // Ass
            primeString.Notifications.Count.Should().Be(2);
            primeString.Valid.Should().BeFalse();
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Objeto em estado invalido com uma notificação de domínio")]
        public void Should_Be_Invalid_Values_For_Prime_String_With_One_Notification()
        {
            // Arr 
            var primeString = new Domain.Models.PrimeString("test", "");

            // Act
            var result = primeString.ArePrimes();
            
            // Ass
            primeString.Notifications.Count.Should().Be(1);
            primeString.Valid.Should().BeFalse();
            result.Should().BeFalse();
        }

        [Theory(DisplayName = "Strings devem ser primas")]
        [InlineData("abcd", "cdab")]
        [InlineData("sacada", "casada")]
        public void Should_Be_Primes_Strings(string firstString, string secondString)
        {
            // Arr 
            var primeString = new Domain.Models.PrimeString(firstString, secondString);

            // Act
            var result = primeString.ArePrimes();
            
            // Ass
            primeString.Notifications.Count.Should().Be(0);
            primeString.Valid.Should().BeTrue();
            result.Should().BeTrue();
        }

        [Theory(DisplayName = "Strings não devem ser primas")]
        [InlineData("oi", "ola")]
        [InlineData("abcd", "dcba")]
        [InlineData("elvis", "lives")]
        public void Should_Be_Not_Primes_Strings(string firstString, string secondString)
        {
            // Arr 
            var primeString = new Domain.Models.PrimeString(firstString, secondString);

            // Act
            var result = primeString.ArePrimes();
            
            // Ass
            primeString.Notifications.Count.Should().Be(0);
            primeString.Valid.Should().BeTrue();
            result.Should().BeFalse();
        }
    }
}
