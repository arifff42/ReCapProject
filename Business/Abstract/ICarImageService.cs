using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImage, IFormFile file);
        IResult Update(CarImage carImage, IFormFile file);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> Get(int id);

        //IResult CheckIfCarImageLimitedExceded(int Id);
        //IResult CheckIfCarImagePathTypeCorrect(string imagePath);
    }
}
