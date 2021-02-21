using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _car;

        public CarManager(ICarDal car)
        {
            _car = car;
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            _car.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();
        }

        public List<Car> GetById(int id)
        {
           return _car.GetById(id);
        }

        public void Update(Car car)
        {
            _car.Update(car);
        }
    }
}
