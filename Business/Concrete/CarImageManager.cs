using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;


            _carImageDal.Add(carImage);

            return new SuccessResult(Message.ProductAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = this.Get(carImage.Id);

            var Deleted = FileHelper.Delete(result.Data.ImagePath);

            if (Deleted.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Message.ProductDeleted);
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = _carImageDal.GetById(id);

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);

            _carImageDal.Update(carImage);

            return new SuccessResult(Message.ProductUpdated);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);

            return new SuccessDataResult<List<CarImage>>(result);
        }


        //---------------------------------------------------------------------------------
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        private IResult CheckIfCarImageLimitedExceded(int Id)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == Id).Count;

            if (result >= 5)
            {
                return new ErrorResult(Message.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImagePathTypeCorrect(string imagePath)
        {
            string acceptableExtensions = ".jpg|png|jpeg";
            if (string.Compare(imagePath, acceptableExtensions) == 0)
            {
                return new ErrorResult(Message.CarImagePathTypeIsFalse);
            }
            return new SuccessResult();
        }
    }
}

