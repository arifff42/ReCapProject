using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal car)
        {
            _cardal = car;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                //Console.WriteLine("Araba İsmi 2 Karakterden Az Olamaz.");

                return new ErrorResult(Message.CarNameEnoughCharacter);
            }
            else if (car.DailyPrice<=0)
            {
                //Console.WriteLine("Araba Fiyatı 0'dan Büyük Olmadılır.");

                return new ErrorResult(Message.CarPriceNotZero);
            }
            else
            {
                _cardal.Add(car);

                //Console.WriteLine("Araç Eklendi");

                return new SuccessResult(Message.ProductAdded);
            }
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);

            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
             var result = _cardal.GetAll();

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
           var result = _cardal.GetById(id);

            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _cardal.GetCarDetails();

            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);

            return new SuccessResult(Message.ProductUpdated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _cardal.GetAll(c => c.BrandId == id);

            return new SuccessDataResult<List<Car>>(result);

        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _cardal.GetAll(c => c.ColorId == id);

            return new SuccessDataResult<List<Car>>(result);
        }
    }
}
