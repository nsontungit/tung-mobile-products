using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace products_api.Controllers
{
    [Route("api/laptops")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOne()
        {
            var result = new
            {
                Name = "Thinkpad3",
                Ram = "16GB",
                Rom = "256GB",
                Price = 223.22
            };
            return Ok(ApiResultCreator.Create(result));
        }
    }
}
