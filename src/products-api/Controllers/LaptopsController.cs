using core.models;
using core.services;
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
        readonly ILaptopsService _laptopService;
        public LaptopsController(ILaptopsService laptopService)
        {
            _laptopService = laptopService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByPage([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var laptops = await _laptopService.GetLaptopsByPage(pageSize, pageNumber);
            return Ok(ApiResultCreator.Create(laptops));
        }
        [HttpGet("options/{type}")]
        public async Task<IActionResult> GetOptions(string type)
        {
            var options = await _laptopService.GetLaptopOptions(type);
            return Ok(ApiResultCreator.Create(options));
        }
        [HttpGet("options/laptop-brand")]
        public async Task<IActionResult> GetLaptopBrandOptions()
        {
            var options = await _laptopService.GetLaptopBrandOptions();
            return Ok(ApiResultCreator.Create(options));
        }
        [HttpGet("options")]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _laptopService.GetAllOptions();
            return Ok(ApiResultCreator.Create(options));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaptop([FromBody]LaptopDto laptopDto)
        {
            await _laptopService.CreateOne(laptopDto);
            return Ok(ApiResultCreator.Create(null, "Create new laptop successfully"));
        }
        
    }
}
