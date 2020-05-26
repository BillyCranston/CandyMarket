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


        // api/Candy/eatCandy/2/user/3
        [HttpDelete("eatCandy/{candyId}/user/{userId}")]
        public IActionResult ConsumeChosenCandy(int candyId, int userId)
        {
            var userExists = _repository.GetUserById(userId);
            if (userExists == null)
            {
                return NotFound("This user does not exist");
            }
            var candyExists = _repository.GetCandyById(candyId);
            if (candyExists == null)
            {
                return NotFound("This candy does not exist");
            }
            var candyConsumed = _repository.ConsumeSpecificCandy(candyId, userId);
            if (candyConsumed == null)
            {
                return NotFound("This candy could not be found for the specified user");
            }
            return Ok(candyConsumed);
        }

        // api/Candy/flavor/chocolate/user/3
        [HttpDelete("flavor/{flavor}/user/{userId}")]
        public IActionResult ConsumeRandomCandyByFlavor(string flavor, int userId)
        {
            var userExists = _repository.GetUserById(userId);
            if (userExists == null)
            {
                return NotFound("This user does not exist");
            }
            var candyExists = _repository.GetCandyByFlavor(flavor);
            if (candyExists == null)
            {
                return NotFound("No candies match this flavor");
            }
            var candyConsumed = _repository.ConsumeRandomCandy(flavor, userId);
            if (candyConsumed == null)
            {
                return NotFound("This candy flavor could not be found for the specified user");
            }
            return Ok(candyConsumed);
        }

        // api/candy/{userId}/consumedCandy
        // api/candy/4/consumedCandy
        [HttpGet("{userId}/consumedCandy")]
        public IActionResult GetConsumedCandyByUserId(int userId)
        {
            var checkForUser = _repository.GetUserById(userId);
            if (checkForUser == null) return NotFound("This user doesn't exist.");

            var candyConsumed = _repository.GetConsumedCandy(userId);
            var isEmpty = !candyConsumed.Any();
            if (isEmpty) return NotFound("This user hasn't consumed any candy");

            return Ok(candyConsumed);
        }
    }
}