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
    public class ProductsController : ControllerBase
    {
        ICarService _carService;

        public ProductsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]

        public /*List<Car>*/ IActionResult Get()
        {
            //ICarService carService = new CarManager(new EfCarDal());

            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]

        public Car Add(Car car)
        {
            ICarService carService = new CarManager(new EfCarDal());

            var result = carService.Add(car);

            return null;// result;
        }


    }
}
