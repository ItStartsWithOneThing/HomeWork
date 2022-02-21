using HomeWork.Models;
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
        private static List<Laptop> _laptops;
        private readonly ILogger<LaptopController> _logger;

        static LaptopController()
        {
            _laptops = new List<Laptop>();

        }

        public LaptopController(ILogger<LaptopController> logger)
        {
            _logger = logger;

        }

        #region GetMethods

        [HttpGet("getAll")] // Without Params
        public IActionResult GetAllLaptops()
        {
            if (_laptops != null)
            {
                _logger.LogInformation("GetAllLaptops: Successfully taken");
                return Ok(_laptops);
            }

            _logger.LogInformation("GetAllLaptops: Couldnt find any");
            return NotFound();
        }

        [HttpGet] // Three Params From Querry
        public IActionResult GetByMultiple([FromQuery] int ram, [FromQuery] int ssd, [FromQuery] string model)
        {
            var dbLaptop = _laptops.FirstOrDefault(x => x.Ram == ram && x.Ssd == ssd && x.Model == model);

            if (dbLaptop != null)
            {
                _logger.LogInformation($"GetByMultiple: Laptop finded by id - {dbLaptop.Id}");
                return Ok(dbLaptop);
            }

            _logger.LogInformation($"GetByMultiple: Laptop with RAM - {ram}, SSD - {ssd}, Model - {model} is not founded");
            return NotFound();
        }

        [HttpGet("{id}")] // One Parameter
        public IActionResult GetById(Guid id)
        {
            var dbLaptop = _laptops.FirstOrDefault(x => x.Id == id);

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

            var dbLaptops = _laptops.Where(x => minRam <= x.Ram && x.Ram <= maxRam);

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
            laptop.Id = Guid.NewGuid();

            if(laptop.Price != 0)
            {
                laptop.Description = "В продаже";
            }
            else
            {
                laptop.Description = "Цена формируется";
            }

            _laptops.Add(laptop);
            _logger.LogInformation($"AddNewLaptop: Added new Laptop with id-{laptop.Id}");
            return Ok(laptop);
        }

        #endregion

        #region DeleteMethod
        [HttpDelete("{id}")]
        public IActionResult DeleteLaptop(Guid id)
        {
            var dbLaptop = _laptops.FirstOrDefault(x => x.Id == id);

            if(dbLaptop != null)
            {
                _laptops.Remove(dbLaptop);
                _logger.LogInformation($"DeleteLaptop: deleted Laptop with id-{dbLaptop.Id}");
                return NoContent();
            }

            _logger.LogInformation($"DeleteLaptop: Laptop wit id-{id} is not found");
            return NotFound();
        }
        #endregion

        #region PutMethod
        [HttpPut]
        public IActionResult UpdateLaptop(Laptop laptop)
        {
            var dbLaptop = _laptops.FirstOrDefault(x => x.Id == laptop.Id);

            if(dbLaptop != null)
            {
                var index = _laptops.IndexOf(laptop);
                _laptops[index] = laptop;
                return Ok(laptop);
            }

            _logger.LogInformation($"UpdateLaptop: Laptop wit id-{laptop.Id} is not found");
            return NotFound();
        }
        #endregion


    }
}
