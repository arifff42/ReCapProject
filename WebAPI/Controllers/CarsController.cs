using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]

        public /*List<Car>*/ IActionResult GetAll()
        {
            //ICarService carService = new CarManager(new EfCarDal());

            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public /*List<Car>*/ IActionResult GetById(int id)
        {
            //ICarService carService = new CarManager(new EfCarDal());

            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public Car Add(Car car)
        {
            ICarService carService = new CarManager(new EfCarDal());

            var result = carService.Add(car);

            return null;// result;
        }
    }
}
