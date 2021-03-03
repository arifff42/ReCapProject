using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Result.Concrete;
using System;
using System.Text;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental() { CarId=5, CustomerId = 1, RentDate = Convert.ToDateTime("03.03.2021") };
            Rental rental2 = new Rental() { Id=4,  ReturnDate = Convert.ToDateTime("03.03.2021") };

            rentalManager.Add(rental1);
            //rentalManager.Update(rental2);
            //rentalManager.Delete(rental2);

            RentalGetAll();

            //GetRentalDetails();
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rent in rentalManager.GetAll().Data)
            {
                System.Console.WriteLine(rent.CarId + " --- " + rent.CustomerId + " --- "

                    + rent.RentDate.Day + "." + rent.RentDate.Month + "." + rent.RentDate.Year + " --- "
                    //+ rent.ReturnDate.Value.Day + "." + rent.ReturnDate.Value.Month + "." + rent.ReturnDate.Value.Year);
                    + rent.ReturnDate); // + "." + rent.ReturnDate + "." + rent.ReturnDate);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { /*CarId = 6,*/ BrandId = 7, ColorId = 6, DailyPrice = 750000, ModelYear = 2021, Description = "Şahin" };
            Car car2 = new Car() { CarId = 3 };
            Car car3 = new Car() { CarId = 3, BrandId = 3, ColorId = 4, ModelYear = 2018, DailyPrice = 450000, Description = "Porche S4" };
            carManager.Add(car1);
        }

        private static void AddUser(UserManager userManager)
        {
            //UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User() { FirstName = "Arif", LastName = "Yıldız", Email = "arif@elzemwax.com", Password = Encoding.ASCII.GetBytes("12345") };
            userManager.Add(user1);
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand() { BrandId = 8, BrandName = "Honda" };

            brandManager.Add(brand1);
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental() { CustomerId = 1, RentDate = Convert.ToDateTime("25.02.2021"), ReturnDate = Convert.ToDateTime("01.03.2021") };

            rentalManager.Add(rental1);
        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rent in rentalManager.GetRentalDetails().Data)
            {
                System.Console.WriteLine(rent.FirstName + " " + rent.LastName + " - " + rent.Description + " - "
                    + rent.ColorName + " - " + rent.ModelYear + " --- " + rent.RentDate.Day + "." + rent.RentDate.Month + "." + rent.RentDate.Year + " --- "
                    + rent.ReturnDate.Day + "." + +rent.ReturnDate.Month + "." + rent.ReturnDate.Year
                    + " ---> " + rent.DailyPrice);
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var cars in carManager.GetCarDetails().Data)
            {
                System.Console.WriteLine(cars.CarId + "-" + cars.BrandName + "-" + cars.ColorName + "-" + cars.Description + "-" + cars.ModelYear + " ---> " + cars.DailyPrice);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var item in carManager.GetCarsByBrandId(2).Data)
            {
                System.Console.WriteLine(item.Description);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brands in brandManager.GetAll().Data)
            {
                System.Console.WriteLine(brands.BrandId + "-" + brands.BrandName);
            }
        }

        private static void CarGetAll(/*CarManager carManager*/)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var cars in carManager.GetAll().Data)
            {
                System.Console.WriteLine(cars.CarId + "-"+cars.Description + "-" + cars.ModelYear + " ---> " + cars.DailyPrice);
            }
        }
    }
}
