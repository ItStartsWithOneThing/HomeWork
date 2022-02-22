using HomeWork.Models;
using HomeWorkBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController : ControllerBase
    {

        private readonly LaptopService _laptopService;
        
        private readonly ILogger<LaptopController> _logger;

        
        public LaptopController(ILogger<LaptopController> logger, LaptopService laptopService)
        {
            _logger = logger;
            _laptopService = laptopService;
        }

        #region GetMethods

        [HttpGet("getAll")] //Using Routing in HttpGetAttribute, Without Params
        public IActionResult GetAllLaptops()
        {
            if (_laptopService.GetAllLaptops() != null)
            {
                _logger.LogInformation("GetAllLaptops: Successfully taken");
                return Ok(_laptopService.GetAllLaptops());
            }

            _logger.LogInformation("GetAllLaptops: Couldnt find any");
            return NotFound();
        }

        [HttpGet] // Three Params From Querry
        public IActionResult GetByMultiple([FromQuery] int ram, [FromQuery] int ssd, [FromQuery] string model)
        {
            var dbLaptop = _laptopService.GetLaptopByMultiple(ram, ssd, model);

            if (dbLaptop != null)
            {
                _logger.LogInformation($"GetByMultiple: Laptop finded with id - {dbLaptop.Id}");
                return Ok(dbLaptop);
            }

            _logger.LogInformation($"GetByMultiple: Laptop with RAM - {ram}, SSD - {ssd}, Model - {model} is not founded");
            return NotFound();
        }

        [HttpGet("{id}")] // One Parameter
        public IActionResult GetById(Guid id)
        {
            var dbLaptop = _laptopService.GetLaptopById(id);

            if (dbLaptop != null)
            {
                _logger.LogInformation($"GetById: Laptop finded by id - {dbLaptop.Id}");
                return Ok(dbLaptop);
            }

            _logger.LogInformation($"GetById: Laptop with id - {id} is not founded");
            return NotFound($"{id}");
        }

        [HttpGet("{minRam}/{maxRam}")] // Getting Range By Two Params with BackSlash "/"
        public IActionResult GetRangeByRam(int minRam, int maxRam)
        {
            if (minRam < 4 || maxRam > 64)
            {
                _logger.LogInformation($"GetRangeByRam: Incorrect input Min-{minRam}, Max-{maxRam}");
                return BadRequest("Неверный ввод. Диагональ дисплея должна быть в диапазоне 11-18'");
            }

            var dbLaptops = _laptopService.GetRangeByRam(minRam, maxRam);

            if (dbLaptops == null)
            {
                _logger.LogInformation($"GetRangeByRam: Result-NotFound. Input Min-{minRam}, Max-{maxRam}");
                return NotFound($"Подходящие ноуты не найдены");
            }

            _logger.LogInformation($"GetRangeByRam: Valid request. Min-{minRam}, Max-{maxRam}");
            return Ok(dbLaptops);
        }

        #endregion

        #region PostMethod

        [HttpPost]
        public IActionResult AddNewLaptop(Laptop laptop)
        {
            if(laptop != null)
            {
                var createdGuid = _laptopService.AddLaptop(laptop);
                _logger.LogInformation($"AddNewLaptop: Added new Laptop with id-{createdGuid}");
                return Created(createdGuid.ToString(), laptop);
            }

            _logger.LogInformation($"AddNewLaptop: nullable Input");
            return BadRequest();
        }

        #endregion

        #region DeleteMethod
        [HttpDelete("{id}")]
        public IActionResult DeleteLaptop(Guid id)
        {
            var deleted = _laptopService.DeleteLaptopById(id);
            if(deleted != null)
            {
                _logger.LogInformation($"DeleteLaptop: Laptop wit id-{id} is deleted");
                return NoContent();
            }

            _logger.LogInformation($"DeleteLaptop: Laptop wit id-{id} is not deleted");
            return NotFound();
        }
        #endregion

        #region PutMethod
        [HttpPut]
        public IActionResult UpdateLaptop(Laptop laptop)
        {
            var updated = _laptopService.UpdateLaptop(laptop);

            if(updated)
            {
                _logger.LogInformation($"UpdateLaptop: Laptop wit id-{laptop.Id} is updated - {updated}");
                return Ok(laptop);
            }

            _logger.LogInformation($"UpdateLaptop: Laptop wit id-{laptop.Id} is updated - {updated}");
            return NotFound();
        }
        #endregion


    }
}
