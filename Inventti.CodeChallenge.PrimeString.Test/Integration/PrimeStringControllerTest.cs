using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Inventti.CodeChallenge.PrimeString.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Inventti.CodeChallenge.PrimeString.Test.Integration
{
    public class PrimeStringControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PrimeStringControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory(DisplayName = "Deve retornar status Ok para valores válidos")]
        [InlineData("oi", "ola")]
        [InlineData("abcd", "dcba")]
        [InlineData("elvis", "lives")]
        public async Task Should_Returns_Ok_For_Valid_Values(string firstString, string secondString)
        {
            // Arr
            var queryString = new QueryString();
            queryString = queryString.Add(nameof(firstString), firstString);
            queryString = queryString.Add(nameof(secondString), secondString);

            // Act
            var response = await _client.GetAsync("/api/PrimeString/StringsArePrimes" + queryString.ToUriComponent());

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string responseData = response.Content.ReadAsStringAsync().Result;
            responseData.Should().NotBeEmpty();
            responseData.Should().NotBeNull();
        }

        [Theory(DisplayName = "Deve retornar BadRequest para valores inválidos")]
        [InlineData("", "ola")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public async Task Should_Returns_Bad_Request_For_Invalid_Values(string firstString, string secondString)
        {
            // Arr
            var queryString = new QueryString();
            queryString = queryString.Add(nameof(firstString), firstString);
            queryString = queryString.Add(nameof(secondString), secondString);

            // Act
            var response = await _client.GetAsync("/api/PrimeString/StringsArePrimes" + queryString.ToUriComponent());

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            string responseData = response.Content.ReadAsStringAsync().Result;
            responseData.Should().NotBeEmpty();
            responseData.Should().NotBeNull();
        }
    }
}