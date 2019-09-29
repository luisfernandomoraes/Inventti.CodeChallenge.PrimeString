using System;
using System.ComponentModel.DataAnnotations;
using Inventti.CodeChallenge.PrimeString.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventti.CodeChallenge.PrimeString.Api.Controllers
{
    /// <summary>
    /// PrimeString API Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeStringController : ControllerBase
    {
        private readonly ICheckStringsServices _checkStringsServices;

        /// <summary>
        /// Creates a instance of PrimeStringController.
        /// </summary>
        /// <param name="checkStringsServices"></param>
        public PrimeStringController(ICheckStringsServices checkStringsServices)
        {
            _checkStringsServices = checkStringsServices;
        }

        /// <summary>
        /// Sipa
        /// </summary>
        /// <returns></returns>
        [HttpGet("Values")]
        public IActionResult GetValues()
        {
            return Ok("deu boa");
        }
        /// <summary>
        /// Check if strings are primes or not.
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        [HttpGet("StringsArePrimes")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public IActionResult CheckStringsArePrimes([FromQuery(Name = "firstString")] [Required(ErrorMessage = "The parameter \'firstString\' is required")] string firstString, [FromQuery(Name = "secondString")] [Required(ErrorMessage = "The parameter \'secondString\' is required")] string secondString)
        {
            try
            {
                return Ok(_checkStringsServices.CheckArePrimes(firstString, secondString));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}