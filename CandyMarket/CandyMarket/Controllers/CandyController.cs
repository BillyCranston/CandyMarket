using System;
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

        // api/candy/{userid}
        // api/candy/5
        [HttpGet("{userid}")]
        public IActionResult GetConsumedCandyByUserId(int userid)
        {
            var candy = _repository.GetById(userid);

            if (candy == null) return NotFound("This user has zero candy.");

            return Ok(candy);
        }
    }
}