using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { CarId = 6, BrandId = 7, ColorId = 6, DailyPrice = 750000, ModelYear = 2021, Description = "Şahin" };
            Car car2 = new Car() { CarId = 3 };
            Car car3 = new Car() { CarId = 3, BrandId = 3, ColorId = 4, ModelYear = 2018, DailyPrice = 450000, Description = "Porche S4" };

            //carManager.Add(car1);

            //carManager.Delete(car1);

            //CarGetAll();

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand() { BrandId = 8, BrandName = "Honda" };

            //brandManager.Add(brand1);

            //BrandGetAll();

            //System.Console.WriteLine(carManager.GetCarsByBrandId(2).ToList());

            //GetCarsByBrandId(carManager);

            GetCarDetails(carManager);

        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var cars in carManager.GetCarDetails())
            {
                System.Console.WriteLine(cars.CarId + "-" + cars.BrandName + "-" + cars.ColorName + "-" + cars.Description + "-" + cars.ModelYear + " ---> " + cars.DailyPrice);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var item in carManager.GetCarsByBrandId(2))
            {
                System.Console.WriteLine(item.Description);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brands in brandManager.GetAll())
            {
                System.Console.WriteLine(brands.BrandId + "-" + brands.BrandName);
            }
        }

        private static void CarGetAll(/*CarManager carManager*/)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var cars in carManager.GetAll())
            {
                System.Console.WriteLine(cars.CarId + "-"+cars.Description + "-" + cars.ModelYear + " ---> " + cars.DailyPrice);
            }
        }
    }
}
