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
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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

       

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));


            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(carImage.CarId, file);
            carImage.Date = DateTime.Now;

            if (carImage.ImagePath==null)
            {

            }

            _carImageDal.Add(carImage);

            return new SuccessResult(Message.ProductAdded);
        }



        [ValidationAspect(typeof(CarImageValidator))]

        public IResult Update(CarImage carImage, IFormFile file)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file,carImage.CarId);

            //_carImageDal.Update(carImage);

            return new SuccessResult(Message.ProductUpdated);
        }


        public IResult Delete(CarImage carImage)
        {
            try
            {
                FileHelper.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            _carImageDal.Delete(carImage);

            return new SuccessResult(Message.ProductDeleted);

            //var result = this.Get(carImage.Id);

            //var Deleted = FileHelper.Delete(result.Data.ImagePath);

            //if (Deleted.Success)
            //{
            //    _carImageDal.Delete(carImage);
            //    return new SuccessResult(Message.ProductDeleted);
            //}
            //return new ErrorResult();
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


        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdExists(carId));

            if (result != null)
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + $@"C:\Users\arif\source\repos\ReCapProject\Images\logo.png");

                return new ErrorDataResult<List<CarImage>>(new List<CarImage>

                { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } }, result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cI => cI.CarId == carId), Message.CarImagesListed);
        }


        //--------------------------------------------------------------------------------------------------------------------------------


        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }


        private IResult CheckIfCarImageLimitedExceded(int id)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == id).Count;

            if (result >= 5)
            {
                return new ErrorResult(Message.CarImageLimitExceded);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCarIdExists(int carId)
        {

            var result = _carImageDal.GetAll(p => p.CarId == carId).Count();

            if (result == 0)
            {
                return new ErrorResult();
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

