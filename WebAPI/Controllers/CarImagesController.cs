using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;


        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        { 
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var result = _carImageService.Add(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {            
            var carImage = _carImageService.Get(id).Data;
            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Id"))] int id, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var carImage = _carImageService.Get(id).Data;
            var result = _carImageService.Update(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("get")]
        public IActionResult Get([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesById([FromForm(Name = ("CarId"))] int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
