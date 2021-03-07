﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> Get(int id);
        //IResult CheckIfCarImageLimitedExceded(int Id);
        //IResult CheckIfCarImagePathTypeCorrect(string imagePath);
    }
}
