using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal car)
        {
            _carDal = car;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);  //  ==  [ValidationAspect(typeof(CarValidator))]

            _carDal.Add(car);

            return new SuccessResult(Message.ProductAdded);

            //---------------------------------------------------------------

                //BU KURALLARI FLUENT VALIDATORDE CARVALIDATOR OLARAK YAZDIK.

            //if (car.Description.Length<2)
            //{
            //    //Console.WriteLine("Araba İsmi 2 Karakterden Az Olamaz.");

            //    return new ErrorResult(Message.CarNameEnoughCharacter);
            //}
            //else if (car.DailyPrice<=0)
            //{
            //    //Console.WriteLine("Araba Fiyatı 0'dan Büyük Olmadılır.");

            //    return new ErrorResult(Message.CarPriceNotZero);
            //}
            //else
            //{
            //    _cardal.Add(car);

            //    //Console.WriteLine("Araç Eklendi");

            //    return new SuccessResult(Message.ProductAdded);
            //}
            //-------------------------------------------------------------------
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
             var result = _carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
           var result = _carDal.GetById(id);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();

            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Message.ProductUpdated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId == id);

            return new SuccessDataResult<List<Car>>(result);

        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll(c => c.ColorId == id);

            return new SuccessDataResult<List<Car>>(result);
        }
    }
}
