
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {    
            _cars = new List<Car> {
                new Car {Id=1, BrandId=1, ColorId=2, ModelYear=2016, DailyPrice=250000, Description="BMW X6"},
                new Car {Id=2, BrandId=2, ColorId=3, ModelYear=2017, DailyPrice=350000, Description="Mercedes S600" },
                new Car {Id=3, BrandId=3, ColorId=4, ModelYear=2018, DailyPrice=450000, Description="Porche S4" },
                new Car {Id=4, BrandId=4, ColorId=5, ModelYear=2019, DailyPrice=550000, Description="Ferrari"  },
                new Car {Id=5, BrandId=5, ColorId=6, ModelYear=2020, DailyPrice=650000, Description="Bentley"},
            };
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<Car> GetAll()
        {           
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carToDelete);
        }
    }
}
