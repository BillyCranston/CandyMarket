﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CandyMarket.DataAccess;

namespace CandyMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandyController : ControllerBase
    {
        CandyRepo _repository;

        public CandyController(CandyRepo repository)
        {
            _repository = repository;
        }

        // api/Candy/eatCandy/2/user/3
        [HttpDelete("eatCandy/{candyId}/user/{userId}")]
        public IActionResult ConsumeChosenCandy(int candyId, int userId)
        {
            var candyConsumed = _repository.ConsumeSpecificCandy(candyId, userId);
            if (candyConsumed == null)
            {
                return NotFound("This candy could not be found for the specified user");
            }
            return Ok(candyConsumed);
        }
    }
}