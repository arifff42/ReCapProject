using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Description.Length<2)
            {
                Console.WriteLine("Araba İsmi 2 Karakterden Az Olamaz.");
            }
            else if (car.DailyPrice<=0)
            {
                Console.WriteLine("Araba Fiyatı 0'dan Büyük Olmadılır.");
            }
            else
            {
                _cardal.Add(car);
                Console.WriteLine("Araç Eklendi");
            }
            
        }

        public void Delete(Car car)
        {
            _cardal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        public List<Car> GetById(int id)
        {
           return _cardal.GetById(id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _cardal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _cardal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _cardal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cardal.GetAll(c => c.ColorId == id);
        }
    }
}
