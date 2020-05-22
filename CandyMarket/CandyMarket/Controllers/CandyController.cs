using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CandyMarket.DataAccess;
using CandyMarket.Models;

namespace CandyMarket.Controllers
{
    [Route("api/Candy")]
    [ApiController]
    public class CandyController : ControllerBase
    {
        CandyRepo _repository;

        public CandyController(CandyRepo repository)
        {
            _repository = repository;
        }

        // api/Candy/{userId}
        [HttpGet("{userId}")]
        public IActionResult GetCandiesByUserId(int userId)
        {
            var user = _repository.GetUserById(userId);
            if (user != null)
            {
                var candies = _repository.GetByUserId(userId);
                var isEmpty = !candies.Any();
                if (isEmpty) return NotFound("No candies found for that user.");

                return Ok(candies);
            }
            else return NotFound("That user does not exist.");
        }

        // api/Candy/{userId}
        [HttpPost("{userId}/addNewCandy")]
        public IActionResult AddNewCandy(int userId, Candy candyToAdd)
        {
            var user = _repository.GetUserById(userId);
            if (user != null)
            {
                var existingCandy = _repository.GetByCandyName(candyToAdd.CandyName);
                if (existingCandy == null)
                {
                    var newCandy = _repository.Add(userId, candyToAdd);
                    _repository.Update(userId, newCandy.CandyId);
                    return Created("", newCandy);
                }
                _repository.Update(userId, existingCandy.CandyId);
                return Ok(candyToAdd);
            }
            return NotFound("That user does not exist.");

        }
    }
}