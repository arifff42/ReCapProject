using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car() { Id = 6, BrandId = 7, ColorId = 9, DailyPrice = 750000, ModelYear = 2021, Description = "Şahin" };
            Car car2 = new Car() { Id = 3};

            carManager.Add(car1);
            carManager.Delete(car2);
            GetAll(carManager);
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var cars in carManager.GetAll())
            {
                System.Console.WriteLine(cars.Id+"-"+cars.Description + "-" + cars.ModelYear + " ---> " + cars.DailyPrice);
            }
        }
    }
}
